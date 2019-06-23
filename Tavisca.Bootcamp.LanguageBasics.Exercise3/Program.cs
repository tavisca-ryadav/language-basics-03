using System;
using System.Linq;

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
            int len = protein.Length,len1=dietPlans.Length;
            int[] ans = new int[len1];
            int[] cal = new int[len];

            for(int i=0;i<len;i++){
                cal[i]= (protein[i]*5 + carbs[i]*5 + fat[i]*9);
                //Console.Write(cal[i]+" , ");
            }
            //Console.Write("\n");

            for(int i=0;i<len1;i++){
                int slen = dietPlans[i].Length;
                int[] visit  = new int[len];

                for(int j=0;j<len;j++){
                visit[j]=1;
                }

                for(int j=0;j<slen;j++){

                    if(dietPlans[i][j]=='p'){
                        minCheck(protein,visit);
                    }
                    if(dietPlans[i][j]=='P'){
                        maxCheck(protein,visit);
                    }
                    if(dietPlans[i][j]=='c'){
                        minCheck(carbs,visit);
                    }
                    if(dietPlans[i][j]=='C'){
                        maxCheck(carbs,visit);
                    }
                    if(dietPlans[i][j]=='f'){
                        minCheck(fat,visit);
                    }
                    if(dietPlans[i][j]=='F'){
                        maxCheck(fat,visit);
                    }
                    if(dietPlans[i][j]=='t'){
                        minCheck(cal,visit);
                    }
                    if(dietPlans[i][j]=='T'){
                        maxCheck(cal,visit);
                    }

                    /*for(int k=0;k<len;k++){
                        Console.Write(visit[k]+" , ");
                }
                Console.Write("\n");*/
                    
                    //Console.Write(check(visit)+"\n");

                    ans[i]=check(visit);

                }

            }
            
            

            for(int i=0;i<ans.Length;i++){
                Console.Write(ans[i]+" , ");
            }

            return ans;
            
        }

        public static void minCheck(int[] nut,int[] visit){
            int min=2000,len=nut.Length;
            for(int k=0;k<len;k++){
                if(nut[k]<min && visit[k]==1){
                    min = nut[k];
                }
            }

            for(int k=0;k<len;k++){
                if(nut[k]==min)
                    visit[k]=1;
                else
                    visit[k]=0;
            }
        }

        public static void maxCheck(int[] nut,int[] visit){
            int max=0,len=nut.Length;
            for(int k=0;k<len;k++){
                if(nut[k]>max && visit[k]==1){
                    max = nut[k];
                }
            }

            for(int k=0;k<len;k++){
                if(nut[k]==max)
                    visit[k]=1;
                else
                    visit[k]=0;
            }
        }

        public static int check(int[] visit){
            for(int i=0;i<visit.Length;i++){
                if(visit[i]==1)
                    return i;
            }
            return 0;;
        }       

    }
}
