using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            var length1 = protein.Length;
            var length2 = dietPlans.Length;

            int[] array = new int[length2];
            int[] calorie = new int[length1];

            // Calculate calorie for each element
            for(var i=0;i<length1;i++){
                calorie[i]= (protein[i]*5 + carbs[i]*5 + fat[i]*9);
            }
         

            for(var i=0;i<length2;i++){
                var stringLen = dietPlans[i].Length;

                //Use a visit array which will keep track of duplicate element values
                int[] visit  = new int[length1];

                for(int j=0;j<length1;j++)
                    visit[j]=1;

                for(int j=0;j<stringLen;j++){
                    
                    //Update visit array according to duplicacy in nutrients

                    if(dietPlans[i][j]=='p'){
                        MinCheck(protein,visit);
                    }
                    if(dietPlans[i][j]=='P'){
                        MaxCheck(protein,visit);
                    }
                    if(dietPlans[i][j]=='c'){
                        MinCheck(carbs,visit);
                    }
                    if(dietPlans[i][j]=='C'){
                        MaxCheck(carbs,visit);
                    }
                    if(dietPlans[i][j]=='f'){
                        MinCheck(fat,visit);
                    }
                    if(dietPlans[i][j]=='F'){
                        MaxCheck(fat,visit);
                    }
                    if(dietPlans[i][j]=='t'){
                        MinCheck(calorie,visit);
                    }
                    if(dietPlans[i][j]=='T'){
                        MaxCheck(calorie,visit);
                    }

                    //Store index in array 
                    array[i] =Check(visit);

                }

            }
            
            return array;
        }

        public static void MinCheck(int[] nutrient,int[] visit){
            var min = 2000;
            var length = nutrient.Length;
            //First find the minmum element in nutrient
            for(var k=0;k<length;k++){
                if(nutrient[k]<min && visit[k]==1){
                    min = nutrient[k];
                }
            }
            //Now check the duplicates on nutrient and update visit array
            for(var k=0;k<length;k++){
                if(nutrient[k]==min)
                    visit[k]=1;
                else
                    visit[k]=0;
            }
        }

        public static void MaxCheck(int[] nutrient,int[] visit){
            var max=0;
            var length=nutrient.Length;
            //First find the maximum element in nutrient
            for(var k=0;k<length;k++){
                if(nutrient[k]>max && visit[k]==1){
                    max = nutrient[k];
                }
            }
             //Now check the duplicates on nutrient and update visit array
            for(var k=0;k<length;k++){
                if(nutrient[k]==max)
                    visit[k]=1;
                else
                    visit[k]=0;
            }
        }

        public static int Check(int[] visit){
            //Find for the first 1 in array visit and return the index else 0
            for(var i=0;i<visit.Length;i++){
                if(visit[i]==1)
                    return i;
            }
            return 0;;
        }       

    }
}
