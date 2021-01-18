using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESMM.Models
{
    public class BootstrapModal
    {
        public string Id { get; set; } = "modalDialog";
        public string AreaLabeledId { get { return this.Id + "Label"; } }
        public string PartialName { get; set; }
        public string Message { get; set; }
        public ModalButton Buttons { get; set; }
        public string ButtonFirstId { get; set; }
        public string ButtonFirstTitle
        { 
            get 
            {
                switch (this.Buttons)
                {
                    case ModalButton.Yes:
                    case ModalButton.YesNo:
                    case ModalButton.YesNoCancel:
                        return "Evet";
                    case ModalButton.Ok:
                    case ModalButton.OkCancel:
                        return "Tamam";
                    case ModalButton.Save:
                    case ModalButton.SaveCancel:
                        return "Kaydet";
                    default:
                        return ButtonFirstTitle;
                }
            }
        }
        public string ButtonSecondId { get; set; }
        public string ButtonSecondTitle
        {
            get
            {
                switch (this.Buttons)
                {
                    case ModalButton.Yes:
                    case ModalButton.YesNo:
                    case ModalButton.YesNoCancel:
                        return "Hayır";
                    case ModalButton.Ok:
                    case ModalButton.OkCancel:
                    case ModalButton.Save:
                    case ModalButton.SaveCancel:
                        return "Vazgeç";
                    default:
                        return ButtonSecondTitle;
                }
            }
        }
        public ModalSize Size { get; set; } = ModalSize.Medium;
        public string ModalSizeClass
        {
            get
            {
                switch (this.Size)
                {
                    case ModalSize.Small:
                        return "modal-sm";
                    case ModalSize.Large:
                        return "modal-lg";
                    case ModalSize.Medium:
                    default:
                        return "";
                }
            }
        }
    }

    public enum ModalSize
    {
        Small,
        Large,
        Medium
    }

    public enum ModalButton
    {
        Yes,
        YesNo,
        YesNoCancel,
        Ok,
        OkCancel,
        Save,
        SaveCancel,
        Custom
    }
}
