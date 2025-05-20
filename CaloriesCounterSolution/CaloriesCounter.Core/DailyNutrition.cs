namespace CaloriesCounter.Core.Models
{
    public class DailyNutrition
    {
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public Dictionary<MealType, double> MealDistribution { get; set; }
    }
}
