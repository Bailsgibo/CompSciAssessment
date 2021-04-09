using System;

namespace ComputerScienceAssessment
{
    class Program
    {


        //input method
        //ask the user for a keyword to find in the .txt file

        //output methods

        //calculator methods

        //reading data from file
        //this method will receive a FileName parameter like (Nutrient.txt) can change file name later (flexibility)
        //What do i do with it?
        //read information from the file line by line and store this information somehow
        //need a string variable to store a line from the txt file
        //and a loop to go through each line in the file
        //what does a line from the file look like?
        //02A10222	"Millet, raw"	1489	11.1	4.2	0.7	63.3	0.4	5
        //What can i do with this info?? deciding whether this method returns a value or not
        //line.Split("  ")


        public static void Main(string[] args)
        {
            //   SearchingFor();
            int num;
            Console.WriteLine("How many ingredients does your recipe have?");
            string ing = Console.ReadLine();

            while (!int.TryParse(ing, out num)) {
                Console.WriteLine("This is not an input! Please try again");
                ing = Console.ReadLine();
            }//end while

            int ingredients = Convert.ToInt32(ing);


            while (ingredients > 0){
            
                Console.WriteLine("What is the keyword that you are searching for?");
                int number;
                bool check = false;
                string SearchingFor = Console.ReadLine();

                while (check == false){
                    SearchingFor = SearchingFor.ToLower();
                        if(string.IsNullOrEmpty(SearchingFor)){
                            Console.WriteLine("This is not a valid input. What are you searching for?");
                            SearchingFor = Console.ReadLine();
                            SearchingFor = SearchingFor.ToLower();
                            check = false;
                            } //end if
                        if(int.TryParse(SearchingFor, out number)){
                            Console.WriteLine("This is not a valid input. What are you searching for?");
                            SearchingFor = Console.ReadLine();
                            SearchingFor = SearchingFor.ToLower();
                            check = false;
                            } //end if
                    if ( SearchingFor.Length > 1){
                        if (SearchingFor[0]>='a' && SearchingFor[0]<='z'){
                            for (int i = 0; i < SearchingFor.Length; i++){
                                if ( SearchingFor[i]>='a' && SearchingFor[i]<='z' || SearchingFor[i]==' '){
                                    check = true;
                                } //end if
                                else{
                                    //check = true;
                                    Console.WriteLine("This is not a valid input. What are you searching for?");
                                    SearchingFor = Console.ReadLine();
                                    SearchingFor = SearchingFor.ToLower();
                                    check = false;
                                } //end else
                            } //end for
                        } //end if check if startinng with space
                        else{
                            Console.WriteLine("This is not a valid input. What are you searching for?");
                                SearchingFor = Console.ReadLine();
                                SearchingFor = SearchingFor.ToLower();
                                check = false;
                        } //end else
                    }
                    else {
                        Console.WriteLine("Input is too short, make it longer. What are you searching for?");
                        SearchingFor = Console.ReadLine();
                        SearchingFor = SearchingFor.ToLower();
                        check = false;
                    }
                    
                    
                    //   Console.WriteLine($"Yay! {SearchingFor}");
                    //checks to see if the input has been read correctly if a valid input has been entered
                    //   string Searched = SearchingFor;
                } //end while

            Console.WriteLine("What is the serving size (in grams) of the item you are looking for?");

            //   if (ServeSize.Contains("."))
            int number1;

            string ServeSize = Console.ReadLine();
            bool valid = false;

            while (valid == false){

                if (int.TryParse(ServeSize, out number1)){
                    valid = true;
                }else{
                    Console.WriteLine("This is not a valid whole number. What is the serving size (in grams) of the item you are looking for?");
                    ServeSize = Console.ReadLine();
                } //end else
                    

            } //end while
                

            /*double num;

            bool valid = false;

            while(valid == false){
                if(double.TryParse(ServeSize, out num)){
                    valid = true;
                        
                }else{ //end if

                    Console.WriteLine("This is not a valid input. Try Again.");
                    ServeSize = Console.ReadLine();
                    valid = false;
                }
            }*/
        

            
            //   Console.WriteLine("Yay!");
            // checks to see if the input is valid
            
            Program p = new Program();
            //calling my 2 methods from Main
            //p.ReadData("Nutrientfile.txt");
            //   int Serve = Convert.ToInt32(ServeSize);
            const string FileName = "Nutrientfile.txt";
            p.ReadData(FileName, SearchingFor, ServeSize);


            ingredients = ingredients - 1;
            Console.WriteLine($"You're search for {SearchingFor} is complete! You have {ingredients} ingredient(s) left.");
            Console.WriteLine("    ");

            } //end while
            

        } //end main

        public void ReadData(string FileName, string SearchingFor, string ServeSize) {

            
            //   string[] NutrientFile = System.IO.File.ReadAllLines(Nutrientfile);
            //   NutrientFile = NutrientFile.ToLower();
            //   Console.WriteLine(NutrientFile[Contains("Beer")]);
            

            //read information line by line from the FileName
            System.IO.StreamReader reader = new System.IO.StreamReader(FileName);

            //read some data from it
            string lineData;
            //   SearchingFor.ToString();

            //   int counter = 0;
            
            
            while ((lineData = reader.ReadLine()) != null ) {

                string [] ArrayData = lineData.Split('\t');
                //   string [] NutrientArray = ArrayData[2].Split(' ');

                //innerarraydata is stuff inside ""
                lineData = lineData.ToLower();

                //   string [] ShortNutrientArray = lineData.Split('\t');


                if (lineData.Contains(SearchingFor)){
                    
                    int ServingSize = Convert.ToInt32(ServeSize);

                    
                    double EnergyArray = Convert.ToDouble(ArrayData[2]); 
                    double Energy = EnergyArray / 100 * ServingSize;
                    double Energy2 = Math.Round(Energy, 2);

                    double ProteinArray = Convert.ToDouble(ArrayData[3]);
                    double Protein = ProteinArray / 100 * ServingSize;
                    double Protein2 = Math.Round(Protein, 2);

                    double FatTArray = Convert.ToDouble(ArrayData[4]);
                    double FatT = FatTArray / 100 * ServingSize;
                    double FatT2 = Math.Round(FatT, 2);

                    double FatSArray = Convert.ToDouble(ArrayData[5]);
                    double FatS = FatSArray / 100 * ServingSize;
                    double FatS2 = Math.Round(FatS, 2);

                    double CarbArray = Convert.ToDouble(ArrayData[6]);
                    double Carb = CarbArray / 100 * ServingSize;
                    double Carb2 = Math.Round(Carb, 2);

                    double SugArray = Convert.ToDouble(ArrayData[7]);
                    double Sug = SugArray / 100 * ServingSize;
                    double Sug2 = Math.Round(Sug, 2);

                    double SodiumArray = Convert.ToDouble(ArrayData[8]);
                    double Sodium = SodiumArray / 100 * ServingSize;
                    double Sodium2 = Math.Round(Sodium, 2);
                    
                    //   Console.WriteLine($"{counter}: {ArrayData[0]} - {ArrayData[1].Replace("\"", "")}");
                    Console.WriteLine($"{ArrayData[0]} - {ArrayData[1].Replace("\"", "")}");
                    Console.WriteLine($"    {Energy2}kJ of Energy per {ServingSize}g");
                    Console.WriteLine($"    {Protein2}g of Protein per {ServingSize}g");
                    Console.WriteLine($"    {FatT2}g of Fat, Total per {ServingSize}g");
                    Console.WriteLine($"    {FatS2}g of Fat, Saturated per {ServingSize}g");
                    Console.WriteLine($"    {Carb2}g of Available Carbohydrate per {ServingSize}g");
                    Console.WriteLine($"    {Sug2}g of Total Sugars per {ServingSize}g");
                    Console.WriteLine($"    {Sodium2}mg of Sodium per {ServingSize}g");
                    Console.WriteLine("   ");

                    
                    //Writes all names of ingredients that are more than 1 word in speech marks
                    //e.g."beer, reduced alcohol or light beer, home-brewed"

                    //   if(innerArrayData.Length <= 3){
                    //   Console.WriteLine(innerArrayData[1].Split(',')[0]);

                    //Writes all lines that have 1 word names 
                    //e.g. Beer

                    //in combination when searching for Beer, prints
                    
                    //   }

                    //   Console.WriteLine (counter.ToString() + ": " + lineData);
                    //writes the whole line of every line that contains the word SearchingFor
                }

                //   counter++;
                    //read each line from the csv file until I reach NULL which is the end
                    //of the file
                    
                    //call your WriteData Method here!
                    //send your arrayData to your method through each iteration of this loop
                
            } //end while



            reader.Close();
                    

        } //end ReadData

        /*
        static void WriteData(string File, string lineData){
            //open a stream/bridge to my new file
            System.IO.StreamWriter writer = new System.IO.StreamWriter(lineData);
            writer.WriteLine(lineData);
            string [] arrayInfo = lineData.Split(" , ");


            for(int i=0; i< arrayInfo.Length; i++) {
                writer.WriteLine($"the index is arrayInfo[{i}]:");
                writer.WriteLine(arrayInfo[i]);
                

        } //end for loop

            writer.Close();

        } //end WriteData 
        */

        
    } //end program

} //end system
