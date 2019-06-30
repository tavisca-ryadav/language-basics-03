using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class NutritionInformation
    {
        public int[] Protein;
        public int[] Carbs;
        public int[] Fat;
        public int[] Calories;
        public const int CaloriesPerGramOfCarbs = 5;
        public const int CaloriesPerGramOfProtein = 5;
        public const int CaloriesPerGramOfFat = 9;
        public const char LessProtein = 'p';
        public const char MoreProtein = 'P';
        public const char LessCarbs = 'c';
        public const char MoreCarbs = 'C';
        public const char LessFat = 'f';
        public const char MoreFat = 'F';
        public const char LessCalories = 't';
        public const char MoreCalories = 'T';

        public NutritionInformation(int[] protein, int[] carbs, int[] fat)
        {
            Protein = protein;
            Carbs = carbs;
            Fat = fat;
            Calories = GetCalories();
        }
        public int[] GetCalories()
        {
            int[] calories = new int[Protein.Length];
            for (int i = 0; i < Protein.Length; i++)
                calories[i] = Carbs[i] * CaloriesPerGramOfCarbs + Protein[i] * CaloriesPerGramOfProtein + Fat[i] * CaloriesPerGramOfFat;
            return calories;
        }
		
		public int GetSuitableDietIndexForPerson(string diet)
        {
            if(string.IsNullOrEmpty(diet))
                return 0;
            var trackVisits  = new int[Protein.Length];
            trackVisits = Enumerable.Repeat(1,Protein.Length).ToArray();

            for(int i=0;i<diet.Length;i++){
                switch(diet[i])
                {
                    case LessProtein:
                        MinimumCheck(Protein,trackVisits);
                        break;
                    case MoreProtein:
                        MaximumCheck(Protein,trackVisits);
                        break;
                    case LessCarbs:
                        MinimumCheck(Carbs,trackVisits);
                        break;
                    case MoreCarbs:
                        MaximumCheck(Carbs,trackVisits);
                        break;
                    case LessFat:
                        MinimumCheck(Fat,trackVisits);
                        break;
                    case MoreFat:
                        MaximumCheck(Fat,trackVisits);
                        break;
                    case LessCalories:
                        MinimumCheck(Calories,trackVisits);
                        break;
                    case MoreCalories:
                        MaximumCheck(Calories,trackVisits);
                        break;
                }
            }

            return CheckVisits(trackVisits);
           
            

		}

        private static void MinimumCheck(int[] nutrient,int[] trackVisits){
            var minimumNutrientValue = 2000;
            //First find the minmum element in nutrient
            for(var k=0;k<nutrient.Length;k++){
                if(nutrient[k]<minimumNutrientValue && trackVisits[k]==1){
                    minimumNutrientValue = nutrient[k];
                }
            }
            //Now check the duplicates on nutrient and update visit array
            for(var k=0;k<nutrient.Length;k++){
                if(nutrient[k]==minimumNutrientValue)
                    trackVisits[k]=1;
                else
                    trackVisits[k]=0;
            }
        }

        private static void MaximumCheck(int[] nutrient,int[] trackVisits){
            var maximumNutrientValue=0;
            //First find the maximum element in nutrient
            for(var k=0;k<nutrient.Length;k++){
                if(nutrient[k]>maximumNutrientValue && trackVisits[k]==1){
                    maximumNutrientValue = nutrient[k];
                }
            }
             //Now check the duplicates on nutrient and update visit array
            for(var k=0;k<nutrient.Length;k++){
                if(nutrient[k]==maximumNutrientValue)
                    trackVisits[k]=1;
                else
                    trackVisits[k]=0;
            }
        }

        private static int CheckVisits(int[] trackVisits){
            //Find for the first 1 in array visit and return the index
            for(var i=0;i<trackVisits.Length;i++){
                if(trackVisits[i]==1)
                    return i;
            }
            return 0;;
        }       
    }
}
