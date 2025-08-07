using Assignment.Question_2;
using Assignment.Question_3;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment
{
    public class Programm
    { 
        static void Main(string[] args)
        {
            #region Part 01
            #region Question 1: What is the primary purpose of an interface in C#?
            //b) To define a blueprint for a class
            //Interfaces defines a contract(blueprint) that classes must follow
            #endregion

            #region Question 2: Which of the following is NOT a valid access modifier for interface members in C#?
            //a) private
            //all members are  implicitly public
            #endregion

            #region Question 3: Can an interface contain fields in C#?
            //b) No
            //It containes only field's signature
            #endregion

            #region Question 4: In C#, can an interface inherit from another interface?
            //b) Yes, interfaces can inherit from multiple interfaces
            #endregion

            #region Question 5: Which keyword is used to implement an interface in a class in C#?
            //None of the above
            //classes use a colon (:) to implement interfaces.
            #endregion

            #region Question 6: Can an interface contain static methods in C#?
            //b) NO
            #endregion

            #region Question 7: In C#, can an interface have explicit access modifiers for its members?
            //b) No, all members are implicitly public
            //All interface members are automatically public.
            #endregion

            #region Question 8: What is the purpose of an explicit interface implementation in C#?
            //b) To provide a clear separation between interface and class members

            #endregion

            #region Question 9: In C#, can an interface have a constructor?
            //b) No, interfaces cannot have constructors
            #endregion

            #region Question 10: How can a C# class implement multiple interfaces?
            //c) By separating interface names with commas
            #endregion

            #endregion

            #region Part 02
            #region Question 01: Define an interface named IShape with a property Area and a method DisplayShapeInfo.Create two interfaces, ICircle and IRectangle, that inherit from IShape.Implement these interfaces in classes Circle and Rectangle. Test your implementation by creating instances of both classes and displaying their shape information.
            //Circle circle = new Circle(2.5);
            ////circle.Area = 10; // Invalid, readonly
            //circle.DisplayShapeInfo();

            //Rectangle rectangle = new Rectangle(20, 10);
            //rectangle.DisplayShapeInfo();

            #endregion

            #region Question 02:
            // defining the IAuthenticationService interface with two methods: AuthenticateUser and AuthorizeUser.
            //BasicAuthenticationService class implements this interface and provides the specific implementation for these methods.

            //In the BasicAuthenticationService class, the AuthenticateUser method compares the provided username and password with the stored credentials
            //It returns true if the user is authenticated and false otherwise

            //The AuthorizeUser method checks if the user with the given username has the specified role.
            //It returns true if the user is authorized and false otherwise.

            //In the Main method, we create an instance of the BasicAuthenticationService class and assign it to the authService variable of type IAuthenticationService.We then call the AuthenticateUser and AuthorizeUser methods using this interface reference.

            //IAuthenticationService authentication = new BasicAuthenticationService();

            //string username = "admin";
            //string password = "1234";
            //string role = "Administrator";

            //bool isAuthenticated = authentication.AuthenticateUser(username, password);
            //Console.WriteLine($"Is 'admin' authenticated? {isAuthenticated}");
            //bool isAuthorized = authentication.AuthorizeUser(username, role);
            //Console.WriteLine($"Is 'admin' authorized? {isAuthorized}");
            //Console.WriteLine();

            //string username2 = "Ali";
            //string password2 = "Pass13";
            //string role2 = "Manager";

            //isAuthenticated = authentication.AuthenticateUser(username2, password2);
            //Console.WriteLine($"Is 'Ali' authenticated? {isAuthenticated}");
            //isAuthorized = authentication.AuthorizeUser(username2, role2);
            //Console.WriteLine($"Is 'Ali' authorized? {isAuthorized}");

            #endregion

            #region Question 03
            //we define the INotificationService interface with a method SendNotification that takes a recipient and a message as parameters.
            //We then create three classes: EmailNotificationService, SmsNotificationService, and PushNotificationService, which implement the INotificationService interface.

            //In each implementation, we provide the logic to send notifications through the respective communication channel:
            //The EmailNotificationService class simulates sending an email by outputting a message to the console.
            //The SmsNotificationService class simulates sending an SMS by outputting a message to the console.



            //INotificationService emailService = new EmailNotificationService();
            //INotificationService smsService = new SmsNotificationService();
            //INotificationService pushService = new PushNotificationService();

            //emailService.SendNotification("rahma@example.com", "Welcome to our platform!");
            //smsService.SendNotification("+201234567890", "Your verification code is 123456.");
            //pushService.SendNotification("rahmaDevice", "You have a new message.");
         

        #endregion
            #endregion

    }
}
}
