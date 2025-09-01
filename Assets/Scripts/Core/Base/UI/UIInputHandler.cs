using System;
using System.Collections.Generic;
using Core.Logger;
using UnityEngine.UI;

namespace MiningFarm.Core.Base
{
    public class UIInputHandler : Loggable
    {
        private readonly Dictionary<string, Button> _buttons = new();
        private readonly Dictionary<string, Action> _actions = new();

        public void RegisterButton(string name, Button button, Action action)
        {
            if (_buttons.ContainsKey(name))
                UnregisterButton(name);

            _buttons[name] = button;
            _actions[name] = action;

            button.onClick.AddListener(() => InvokeAction(name));
        }

        public void RegisterButton<T>(string name, Button button, Action<T> action, T arg)
        {
            if (_buttons.ContainsKey(name))
                UnregisterButton(name);

            _buttons[name] = button;
            _actions[name] = () => action(arg);

            button.onClick.AddListener(() => InvokeAction(name));
        }

        public void RegisterButton<T1, T2>(string name, Button button, Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (_buttons.ContainsKey(name))
                UnregisterButton(name);

            _buttons[name] = button;
            _actions[name] = () => action(arg1, arg2);

            button.onClick.AddListener(() => InvokeAction(name));
        }

        public void RegisterButton<T1, T2, T3>(string name, Button button, Action<T1, T2, T3> action, T1 arg1, T2 arg2,
            T3 arg3)
        {
            if (_buttons.ContainsKey(name))
                UnregisterButton(name);

            _buttons[name] = button;
            _actions[name] = () => action(arg1, arg2, arg3);

            button.onClick.AddListener(() => InvokeAction(name));
        }

        public void UnregisterButton(string name)
        {
            if (_buttons.TryGetValue(name, out var button))
            {
                button.onClick.RemoveAllListeners();
                _buttons.Remove(name);
                _actions.Remove(name);
            }
        }

        public void UnregisterAllButtons()
        {
            foreach (var button in _buttons)
            {
                button.Value.onClick.RemoveAllListeners();
            }

            _buttons.Clear();
            _actions.Clear();
        }

        private void InvokeAction(string name)
        {
            if (_actions.TryGetValue(name, out var action))
            {
                action?.Invoke();
            }
            else
            {
                Logger.LogWarning($"No action found for button: {name}", Tag);
            }
        }
    }
}