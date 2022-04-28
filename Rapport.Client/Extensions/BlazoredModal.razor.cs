﻿//using Microsoft.AspNetCore.Components;
//using System.Collections.ObjectModel;
//using ModalPosition = Rapport.Shared.Enums.ModalPosition;
//using ModalResult = Rapport.Shared.Service.ModalResult;

//namespace Rapport.Client.Extensions
//{
//    public partial class BlazoredModal : ComponentBase
//    {
//        [Inject] private NavigationManager NavigationManager { get; set; }    
//        [Inject] private IModalService ModalService { get; set; }
//        [CascadingParameter] private IModalService CascadedModalService { get; set; } = default!;

//        [Parameter] public bool? HideHeader { get; set; }
//        [Parameter] public bool? HideCloseButton { get; set; }
//        [Parameter] public bool? DisableBackgroundCancel { get; set; }
//        [Parameter] public string? OverlayCustomClass { get; set; }
//        [Parameter] public ModalPosition? Position { get; set; }
//        [Parameter] public string? PositionCustomClass { get; set; }
//        [Parameter] public string? Class { get; set; }
//        [Parameter] public ModalAnimation? Animation { get; set; }
//        [Parameter] public bool? UseCustomLayout { get; set; }
//        [Parameter] public bool? ContentScrollable { get; set; }
//        [Parameter] public bool? ActivateFocusTrap { get; set; }

//        private readonly Collection<ModalReference> _modals = new();
//        private readonly ModalOptions _globalModalOptions = new();

//        internal event Action? OnModalClosed;

//        protected override void OnInitialized()
//        {
//            if (CascadedModalService == null)
//            {
//                throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(IModalService)}.");
//            }

//            ((ModalService)CascadedModalService).OnModalInstanceAdded += Update;
//            ((ModalService)CascadedModalService).OnModalCloseRequested += CloseInstance;
//            NavigationManager.LocationChanged += CancelModals;

//            _globalModalOptions.Class = Class;
//            _globalModalOptions.DisableBackgroundCancel = DisableBackgroundCancel;
//            _globalModalOptions.HideCloseButton = HideCloseButton;
//            _globalModalOptions.HideHeader = HideHeader;
//            _globalModalOptions.Position = Position;
//            _globalModalOptions.PositionCustomClass = PositionCustomClass;
//            _globalModalOptions.Animation = Animation;
//            _globalModalOptions.OverlayCustomClass = OverlayCustomClass;

//            _globalModalOptions.UseCustomLayout = UseCustomLayout;
//            _globalModalOptions.ContentScrollable = ContentScrollable;
//            _globalModalOptions.ActivateFocusTrap = ActivateFocusTrap;
//        }

//        internal async void CloseInstance(ModalReference? modal, ModalResult result)
//        {
//            if (modal?.ModalInstanceRef != null)
//            {
//                // Gracefully close the modal
//                await modal.ModalInstanceRef.CloseAsync(result);
//                OnModalClosed?.Invoke();
//            }
//            else
//            {
//                await DismissInstance(modal, result);
//            }
//        }

//        internal Task DismissInstance(Guid id, ModalResult result)
//        {
//            var reference = GetModalReference(id);
//            return DismissInstance(reference, result);
//        }

//        internal async Task DismissInstance(ModalReference? modal, ModalResult result)
//        {
//            if (modal != null)
//            {
//                modal.Dismiss(result);
//                _modals.Remove(modal);
//                await InvokeAsync(StateHasChanged);
//                OnModalClosed?.Invoke();
//            }
//        }

//        private async void CancelModals(object? sender, LocationChangedEventArgs e)
//        {
//            foreach (var modalReference in _modals.ToList())
//            {
//                modalReference.Dismiss(ModalResult.Cancel());
//            }

//            _modals.Clear();
//            await InvokeAsync(StateHasChanged);
//        }

//        private async void Update(ModalReference modalReference)
//        {
//            _modals.Add(modalReference);
//            await InvokeAsync(StateHasChanged);
//        }

//        private ModalReference? GetModalReference(Guid id)
//            => _modals.SingleOrDefault(x => x.Id == id);
//    }
//}
