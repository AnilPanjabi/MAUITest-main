namespace MAUITest.UI.CustomControls;

public partial class MonthYearPicker : ContentView
{
	public MonthYearPicker()
	{
		InitializeComponent();
        SetupMonthYearPicker();
    }

    public static readonly BindableProperty SelectedMonthProperty =
          BindableProperty.Create(nameof(SelectedMonth), typeof(int), typeof(int), 0, BindingMode.TwoWay);

    public int SelectedMonth
    {
        get { return (int)GetValue(SelectedMonthProperty); }
        set { SetValue(SelectedMonthProperty, value); }
    }

    public static readonly BindableProperty SelectedYearProperty =
          BindableProperty.Create(nameof(SelectedYear), typeof(int), typeof(int), 0, BindingMode.TwoWay);

    public int SelectedYear
    {
        get { return (int)GetValue(SelectedYearProperty); }
        set { SetValue(SelectedYearProperty, value); }
    }

    private void SetupMonthYearPicker()
    {
        // Populate months
        var months = Enumerable.Range(01, 12).Select(m => m).ToList();
        MonthPicker.ItemsSource = months;

        // Populate years (e.g., from the current year to current year + 10)
        var currentYear = DateTime.Now.Year;
        var years = Enumerable.Range(currentYear, 10).Select(y => y).ToList();
        YearPicker.ItemsSource = years;
    }

    private void OnMonthSelected(object sender, EventArgs e)
    {
        SelectedMonth = (int)MonthPicker.SelectedItem;
    }

    private void OnYearSelected(object sender, EventArgs e)
    {
        SelectedYear = (int)YearPicker.SelectedItem;
    }

}
