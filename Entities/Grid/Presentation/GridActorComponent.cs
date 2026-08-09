using CM.Core.Application;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorComponent : MonoBehaviour
    {
        [Inject]
        public GridActorFacade Facade { get; private set; }
    }
}
