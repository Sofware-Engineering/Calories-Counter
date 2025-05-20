namespace CaloriesCounter.Core.Models
{
    public class CalorieResult
    {
        public int UserProfileId { get; set; }
        public DateTime CalculationDate { get; set; }
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double DailyCalories { get; set; }
        public double WeeklyCalories { get; set; }
        public Dictionary<DayOfWeek, DailyNutrition> WeeklyPlan { get; set; } = new();
    }
}
