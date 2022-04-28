using Blazored.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Configuration
{
    public class ModalAnimation
    {
        public ModalAnimationType Type { get; set; }
        public double? Duration { get; set; }

        public ModalAnimation(ModalAnimationType type, double duration)
        {
            Type = type;
            Duration = duration;
        }

        public static ModalAnimation FadeIn(double duration) => new(ModalAnimationType.FadeIn, duration);
        public static ModalAnimation FadeOut(double duration) => new(ModalAnimationType.FadeOut, duration);
        public static ModalAnimation FadeInOut(double duration) => new(ModalAnimationType.FadeInOut, duration);
    }


}
