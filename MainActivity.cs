using Android.Text;
using Android.Widget;
using System.Globalization;
using Android.Graphics;

namespace calcolatore_carboidrati
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        private EditText? editTextCarbo;
        private EditText? editTextPeso;
        private TextView? textViewResult;
        private TextView? textViewTitle;
        private TextView? textViewCarboLabel;
        private TextView? textViewPesoLabel;
        private TextView? textViewResultLabel;
        private TextView? textViewPer100g;
        private TextView? textViewFormula;
        private TextView? textViewAuthor;
        private ImageView? imageViewFlag;
        
        private bool isItalian = true; // Default to Italian

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Initialize views
            editTextCarbo = FindViewById<EditText>(Resource.Id.editTextCarbo);
            editTextPeso = FindViewById<EditText>(Resource.Id.editTextPeso);
            textViewResult = FindViewById<TextView>(Resource.Id.textViewResult);
            textViewTitle = FindViewById<TextView>(Resource.Id.textViewTitle);
            textViewCarboLabel = FindViewById<TextView>(Resource.Id.textViewCarboLabel);
            textViewPesoLabel = FindViewById<TextView>(Resource.Id.textViewPesoLabel);
            textViewResultLabel = FindViewById<TextView>(Resource.Id.textViewResultLabel);
            textViewPer100g = FindViewById<TextView>(Resource.Id.textViewPer100g);
            textViewFormula = FindViewById<TextView>(Resource.Id.textViewFormula);
            textViewAuthor = FindViewById<TextView>(Resource.Id.textViewAuthor);
            imageViewFlag = FindViewById<ImageView>(Resource.Id.imageViewFlag);

            // Set up flag click listener
            if (imageViewFlag != null)
            {
                imageViewFlag.Click += OnFlagClicked;
            }

            // Set up text changed listeners for real-time calculation
            if (editTextCarbo != null)
            {
                editTextCarbo.TextChanged += OnInputTextChanged;
                // Add input filter to allow only numeric input with decimal point
                editTextCarbo.SetFilters(new IInputFilter[] { new DecimalInputFilter() });
            }

            if (editTextPeso != null)
            {
                editTextPeso.TextChanged += OnInputTextChanged;
                // Add input filter to allow only numeric input with decimal point
                editTextPeso.SetFilters(new IInputFilter[] { new DecimalInputFilter() });
            }

            // Initial language setup
            UpdateLanguage();
            
            // Initial calculation
            CalculateResult();
        }

        private void OnFlagClicked(object? sender, EventArgs e)
        {
            isItalian = !isItalian;
            UpdateLanguage();
            // Recalculate to update error messages if any
            CalculateResult();
        }

        private void UpdateLanguage()
        {
            if (imageViewFlag == null) return;

            if (isItalian)
            {
                // Set Italian flag and texts
                imageViewFlag.SetImageResource(Resource.Drawable.flag_italy);
                if (textViewTitle != null) textViewTitle.Text = "Calcolatore CHO";
                if (textViewCarboLabel != null) textViewCarboLabel.Text = "Carboidrati da tabella nutrizionale";
                if (textViewPesoLabel != null) textViewPesoLabel.Text = "Peso";
                if (textViewResultLabel != null) textViewResultLabel.Text = "Risultato";
                if (textViewPer100g != null) textViewPer100g.Text = "ogni 100 grammi";
                if (textViewFormula != null) textViewFormula.Text = "Formula: (Carboidrati × Peso) ÷ 100";
                if (textViewAuthor != null) textViewAuthor.Text = "creato da Matteo Gabriele";
                if (editTextCarbo != null) editTextCarbo.Hint = "Inserisci carboidrati";
                if (editTextPeso != null) editTextPeso.Hint = "Inserisci peso";
            }
            else
            {
                // Set UK flag and English texts
                imageViewFlag.SetImageResource(Resource.Drawable.flag_uk);
                if (textViewTitle != null) textViewTitle.Text = "CHO Calculator";
                if (textViewCarboLabel != null) textViewCarboLabel.Text = "Carbohydrates from the nutritional table";
                if (textViewPesoLabel != null) textViewPesoLabel.Text = "Weight";
                if (textViewResultLabel != null) textViewResultLabel.Text = "Result";
                if (textViewPer100g != null) textViewPer100g.Text = "per 100 grams";
                if (textViewFormula != null) textViewFormula.Text = "Formula: (Carbohydrates × Weight) ÷ 100";
                if (textViewAuthor != null) textViewAuthor.Text = "created by Matteo Gabriele";
                if (editTextCarbo != null) editTextCarbo.Hint = "Enter carbohydrates";
                if (editTextPeso != null) editTextPeso.Hint = "Enter weight";
            }
        }

        private void OnInputTextChanged(object? sender, TextChangedEventArgs e)
        {
            CalculateResult();
        }

        private void CalculateResult()
        {
            if (editTextCarbo == null || editTextPeso == null || textViewResult == null)
                return;

            try
            {
                string carboText = editTextCarbo.Text?.Trim() ?? "";
                string pesoText = editTextPeso.Text?.Trim() ?? "";

                // Reset carbo field background to normal
                editTextCarbo.SetBackgroundResource(Resource.Drawable.rounded_edittext);

                // If either field is empty, show 0
                if (string.IsNullOrEmpty(carboText) || string.IsNullOrEmpty(pesoText))
                {
                    textViewResult.Text = "0";
                    textViewResult.SetTextColor(Color.ParseColor("#27ae60"));
                    return;
                }

                // Parse the values using invariant culture to handle decimal points correctly
                if (double.TryParse(carboText, NumberStyles.Float, CultureInfo.InvariantCulture, out double carbo) &&
                    double.TryParse(pesoText, NumberStyles.Float, CultureInfo.InvariantCulture, out double peso))
                {
                    // Check if carbo value is greater than 100
                    if (carbo > 100)
                    {
                        // Set error background for carbo field
                        editTextCarbo.SetBackgroundResource(Resource.Drawable.rounded_edittext_error);
                        
                        // Show error message based on current language
                        string errorMessage = isItalian ? "valore non corretto" : "incorrect value";
                        
                        textViewResult.Text = errorMessage;
                        textViewResult.SetTextColor(Color.ParseColor("#c0392b"));
                        return;
                    }

                    // Calculate: (carbo * peso) / 100
                    double result = (carbo * peso) / 100.0;
                    
                    // Format result as integer (no decimals)
                    textViewResult.Text = Math.Round(result).ToString("F0", CultureInfo.InvariantCulture);
                    textViewResult.SetTextColor(Color.ParseColor("#27ae60"));
                }
                else
                {
                    textViewResult.Text = "0";
                    textViewResult.SetTextColor(Color.ParseColor("#27ae60"));
                }
            }
            catch (Exception)
            {
                textViewResult.Text = "0";
                textViewResult.SetTextColor(Color.ParseColor("#27ae60"));
            }
        }
    }

    // Custom input filter to allow only numeric input with decimal point
    public class DecimalInputFilter : Java.Lang.Object, IInputFilter
    {
        public Java.Lang.ICharSequence? FilterFormatted(Java.Lang.ICharSequence? source, int start, int end, ISpanned? dest, int dstart, int dend)
        {
            if (source == null) return null;

            string sourceText = source.ToString();
            string destText = dest?.ToString() ?? "";
            
            // Build the resulting string
            string resultText = destText.Substring(0, dstart) + sourceText + destText.Substring(dend);
            
            // Allow empty string
            if (string.IsNullOrEmpty(resultText))
                return null;

            // Check if the result is a valid decimal number
            if (System.Text.RegularExpressions.Regex.IsMatch(resultText, @"^\d*\.?\d*$"))
            {
                // Check for multiple decimal points
                int decimalCount = resultText.Count(c => c == '.');
                if (decimalCount <= 1)
                {
                    return null; // Accept the input
                }
            }

            // Reject the input
            return new Java.Lang.String("");
        }
    }
}