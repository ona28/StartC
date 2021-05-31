using System.Collections.Generic;

namespace Boxes
{
    public sealed class Controllers : IAwake, IStart, IUpdate, IFixUpdate, ILateUpdate, IEnable, IDisable
    {
        private readonly List<IAwake> _awakeControllers;
        private readonly List<IStart> _startControllers;
        private readonly List<IUpdate> _updateControllers;
        private readonly List<IFixUpdate> _fixUpdateControllers;
        private readonly List<ILateUpdate> _lateUpdateControllers;
        private readonly List<IEnable> _enableControllers;
        private readonly List<IDisable> _diasbleControllers;

        internal Controllers()
        {
            _awakeControllers = new List<IAwake>();
            _startControllers = new List<IStart>();
            _updateControllers = new List<IUpdate>();
            _fixUpdateControllers = new List<IFixUpdate>();
            _lateUpdateControllers = new List<ILateUpdate>();
            _enableControllers = new List<IEnable>();
            _diasbleControllers = new List<IDisable>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IAwake awakeController)
            {
                _awakeControllers.Add(awakeController);
            }

            if (controller is IStart startController)
            {
                _startControllers.Add(startController);
            }

            if (controller is IUpdate updateController)
            {
                _updateControllers.Add(updateController);
            }

            if (controller is IFixUpdate fixUpdateController)
            {
                _fixUpdateControllers.Add(fixUpdateController);
            }

            if (controller is ILateUpdate lateUpdateController)
            {
                _lateUpdateControllers.Add(lateUpdateController);
            }

            if (controller is IEnable enableController)
            {
                _enableControllers.Add(enableController);
            }

            if (controller is IDisable disableController)
            {
                _diasbleControllers.Add(disableController);
            }

            return this;
        }

        public void Awake()
        {
            for (var i = 0; i < _awakeControllers.Count; i++)
            {
                _awakeControllers[i].Awake();
            }
        }

        public void Start()
        {
            for (var i = 0; i < _startControllers.Count; i++)
            {
                _startControllers[i].Start();
            }
        }

        public void Update(float deltaTime)
        {
            for (var i = 0; i < _updateControllers.Count; i++)
            {
                _updateControllers[i].Update(deltaTime);
            }
        }

        public void FixUpdate(float deltaTime)
        {
            for (var i = 0; i < _fixUpdateControllers.Count; i++)
            {
                _fixUpdateControllers[i].FixUpdate(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            for (var i = 0; i < _lateUpdateControllers.Count; i++)
            {
                _lateUpdateControllers[i].LateUpdate(deltaTime);
            }
        }

        public void Enable()
        {
            for (var i = 0; i < _enableControllers.Count; i++)
            {
                _enableControllers[i].Enable();
            }
        }

        public void Disable()
        {
            for (var i = 0; i < _diasbleControllers.Count; i++)
            {
                _diasbleControllers[i].Disable();
            }
        }
    }
}

