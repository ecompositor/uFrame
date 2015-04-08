using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class ViewService : SystemServiceMonoBehavior
{
    private List<ViewBase> _views;

    public override void Setup()
    {
        this.OnEvent<InstantiateViewCommand>()
            .Subscribe(InstantiateView);

        this.OnEvent<ViewCreatedEvent>()
            .Subscribe(ViewCreated);

        this.OnEvent<KernalLoadedEvent>()
            .Subscribe(Loaded);
    }

    public List<ViewBase> Views
    {
        get { return _views ?? (_views = new List<ViewBase>()); }
        set { _views = value; }
    }

    private void InstantiateView(InstantiateViewCommand data)
    {
        var scene = data.Scene as Scene;
        
        GameObject viewPrefab = null;
        if (data.ViewModelObject != null)
        {
            viewPrefab = uFrameMVVMKernel.ViewResolver.FindView(data.ViewModelObject);
        }
        else
        {
            viewPrefab = uFrameMVVMKernel.ViewResolver.FindView(data.Identifier);
        }
        var result = Instantiate(viewPrefab) as GameObject;
        var resultView = result.GetComponent<ViewBase>();
        resultView.CreateEventData = new ViewCreatedEvent()
        {
            IsInstantiated = true,
            View = resultView,
            Scene = data.Scene,
        };

        if (scene != null)
            resultView.transform.parent = scene.transform;

        data.Result = resultView;
    }

    private void Loaded(KernalLoadedEvent data)
    {
        foreach (var view in Views.Where(p=>!p.CreateEventData.IsInstantiated))
        {
            view.SetViewModelObjectSilently(FetchViewModel(view));
        }
        foreach (var view in Views.Where(p => !p.CreateEventData.IsInstantiated))
        {
            view.SetupBindings();
        }
    }

    private void ViewCreated(ViewCreatedEvent viewCreatedEvent)
    {
        var view = viewCreatedEvent.View;
        var viewModel = FetchViewModel(viewCreatedEvent.View);
        view.ViewModelObject = viewModel;
        Views.Add(view);
    }

    /// <summary>
    /// This is method is called by each view in order to get it's view-model as well as place it in
    /// the SceneContext if the "Save & Load" option is checked in it's inspector
    /// </summary>
    /// <param name="viewBase">The view that is requesting it's view-model.</param>
    /// <returns>A new view model or the view-model with the identifier specified found in the scene context.</returns>
    public ViewModel FetchViewModel(ViewBase viewBase)
    {
        if (viewBase.InjectView)
        {
            uFrameMVVMKernel.Container.Inject(viewBase);
        }
        // Attempt to resolve it by the identifier 
        var contextViewModel = uFrameMVVMKernel.Container.Resolve<ViewModel>(viewBase.Identifier);
        // If it doesn't resolve by the identifier we need to create it
        if (contextViewModel == null)
        {
            // Either use the controller to create it or create it ourselves
            contextViewModel = Activator.CreateInstance(viewBase.ViewModelType, EventAggregator) as ViewModel;
            contextViewModel.Identifier = viewBase.Identifier;
       
            // Register it, this is usually when a non registered element is treated like a single-instance anways
            uFrameMVVMKernel.Container.RegisterInstance(viewBase.ViewModelType, contextViewModel,
                    string.IsNullOrEmpty(viewBase.Identifier) ? null : viewBase.Identifier);

            // Register it under the generic view-model type
            uFrameMVVMKernel.Container.RegisterInstance<ViewModel>(contextViewModel, viewBase.Identifier);
       
            this.Publish(new ViewModelCreatedEvent()
            {
                ViewModel = contextViewModel
            });
        }
        // If we found a view-model
        if (contextViewModel != null)
        {
            // If the view needs to be overriden it will initialize with the inspector values
            if (viewBase.OverrideViewModel)
            {
                viewBase.InitializeData(contextViewModel);
            }
        }
        return contextViewModel;
    }
}