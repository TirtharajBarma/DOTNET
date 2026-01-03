using System;
class Conditional {
    public static void cal() {
        //! check for age
        // int age = 21;
        // if(age < 18) {
        //     Console.WriteLine("Not Adult");
        // }
        // else {
        //     Console.WriteLine("Adult");
        // }

        //! even-odd
        // int num = 3;
        // if(num % 2 == 0)
        // {
        //     Console.WriteLine("Even");
        // }
        // else
        // {
        //     Console.WriteLine("Odd");
        // }

        //! nested
        int age = 22;
        bool hasLicense = false;

        if(age >= 18)
        {
            if (hasLicense)
            {
                Console.WriteLine("Ready to drive");
            } else
            {
                Console.WriteLine("Eligible but don't have license");
            }
        }
        else
        {
            Console.WriteLine("Not");
        }
    }
}