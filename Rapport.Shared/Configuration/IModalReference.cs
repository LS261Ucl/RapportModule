using Blazored.Modal.Services;

namespace Rapport.Shared.Configuration
{
    public interface IModalReference
    {
        Task<ModalResult> Result { get; }

        //void Close();
        //void Close(ModalResult result);
    }
}
