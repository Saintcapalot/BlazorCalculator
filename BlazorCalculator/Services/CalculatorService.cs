namespace BlazorCalculator.Services
{
    public class CalculatorService
    {
        private decimal _currentValue = 0;
        private decimal? _previousValue = null;
        private string? _pendingOperator = null;
        private bool _shouldClearOnNextInput = false;

        public string? LastError { get; private set; }

        public decimal CurrentValue => _currentValue;

        public void InputNumber(string digit)
        {
            LastError = null;

            if (_shouldClearOnNextInput)
            {
                _currentValue = 0;
                _shouldClearOnNextInput = false;
            }

            var text = _currentValue.ToString();

            if (text == "0")
                text = digit;
            else
                text += digit;

            _currentValue = decimal.Parse(text);
        }

        public void InputDecimal()
        {
            LastError = null;

            if (_shouldClearOnNextInput)
            {
                _currentValue = 0;
                _shouldClearOnNextInput = false;
            }

            var text = _currentValue.ToString();

            if (!text.Contains(",") && !text.Contains("."))
            {
                // norsk variant
                text += ",";
                _currentValue = decimal.Parse(text);
            }
        }

        public void ToggleSign()
        {
            LastError = null;
            _currentValue = _currentValue * -1;
        }

        public void AllClear()
        {
            _currentValue = 0;
            _previousValue = null;
            _pendingOperator = null;
            _shouldClearOnNextInput = false;
            LastError = null;
        }

        public void SetOperator(string op)
        {
            LastError = null;

            if (_previousValue == null)
            {
                _previousValue = _currentValue;
            }
            else if (_pendingOperator != null)
            {
                Execute();
            }

            _pendingOperator = op;
            _shouldClearOnNextInput = true;
        }

        public void Execute()
        {
            LastError = null;

            if (_pendingOperator == null || _previousValue == null)
                return;

            switch (_pendingOperator)
            {
                case "+":
                    _currentValue = _previousValue.Value + _currentValue;
                    break;
                case "-":
                    _currentValue = _previousValue.Value - _currentValue;
                    break;
                case "x":
                case "*":
                    _currentValue = _previousValue.Value * _currentValue;
                    break;
                case "/":
                    if (_currentValue == 0)
                    {
                        LastError = "Kan ikke dele på 0";
                        // ikke kast exception, bare stopp
                        _currentValue = 0;
                        _previousValue = null;
                        _pendingOperator = null;
                        _shouldClearOnNextInput = false;
                        return;
                    }
                    _currentValue = _previousValue.Value / _currentValue;
                    break;
            }

            _previousValue = null;
            _pendingOperator = null;
            _shouldClearOnNextInput = true;
        }

        public void Clear()
        {
            _currentValue = 0;
            _shouldClearOnNextInput = false;
            LastError = null;
        }
    }
}
