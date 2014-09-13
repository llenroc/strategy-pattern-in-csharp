**# Strategy Pattern Using C# #**

**Created by: Roberto Cervantes (rcervantes@outlook.com)**

When we build applications with similar features, we try to handle a reusable and decoupled logic, the same experience that we feel when we use LEGO toys, some patterns help us to create custom blocks to encapsulate an specific functionality.

Imagine that you have different business application clients that share a specific functionality, and you need to submit an order for validations.

This functionality needs to apply business rules validations, send mails to involved people that will approve the order and create a report that specify all the detail of the order.

To achieve this goal we can think in different solutions:

**Approach 1: Keep it Separated**

Create each manager with its own logic completely decoupled one of each other, at this point we are prepared for changes, if changes comes we only affect the isolated logic, but, what´s happen if code increase and the logic becomes more and more complex? Yes, in a couple of months the maintenance of more than one similar logic will be tedious and a bit complex, even if all business wants the same specific common rule but with different tasks.

**Approach 2: Generic Manager**

Create a generic manager that submit the order for approval and implement it in each client, could be the solution, but what´s happen if one of our clients need to add more validations or perform another tasks after approve the order. At this point we can extend our generic manager with the new features requested by the client, but the others business clients will be impacted since they don´t need this functionality, or create another manager that contains the new features, but… where´s is my generic manager? Yes, there´s no more generic manager, since we have duplicated code, and overhead the functionality, the others application clients don´t need the new functionality, so, why put it together in the same logic?

**Approach 3: ¿So, what can I do to invest the less amount of effort and let prepared my application for future changes?**

The answer is in the use of design patterns, build an app thinking in changes, allows you to move smoothly between new features, and at this point we are going to review the strategic design pattern.

** How I implement the strategic design pattern in this application design?**

Let’s open Visual Studio and create a new project BusinessTasks.Commons.

This library will be deployed with all our clients and will contain the generic logic that will help us to perform our common tasks.

Create a class and name it ManagerBase, this class will contain the public contracts that will be used for each client library, and also will contains the behaviors of each logic. Remember, at this point we don’t know how the logic will be implemented but we know it must be implemented.

Identify the main activities the approval needs to do, for example:

   * Validate the order.
   * Send an email.
   * Create report.
   * Other tasks. 

For each activity create an interface that will allow us to implement the logic in a custom way for each client.

![diagram1.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/diagram1.png)

At this moment, we design a manager class that have methods that will be implemented in different ways for each client, now imagine that all orders that pass across our validation process needs to be auditable, this functionality is not necessary to be implemented in each client and it doesn’t involve business changes, the order comes from the IT Security Department.

![diagram2.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/diagram2.png)

To accomplish the IT security issue, we add a new internal class called Audit, and a new method in our Manager to save our audit trace.

It’s time to code the SubmitForApproval our generic method that will be used by many clients to validate their orders.

![class1.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/class1.png)

Now, we have library that can handle the common aspects of our new features. It’s time to implement a new business client using our base manager.

Suppose we have two business clients: Awesome and Great. Let’s going to create a new project BusinessTasks.Awesome and add the reference of our BusinessTasks.Commons.

Create a new class and name it SubmitForApproval, remember this class inherits from ManagerBase class.

Now it’s time to create our four activity classes where we are going to build the logic for this client. Create four classes, each class must implement each interface wrote before in BusinessTasks.Commons.

![class2.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/class2.png)

Inside of each class method we will define the logic the requirement needs for this client.

Now it’s time to initialize our constructors for each behavior in the SubmitForApproval constructor.

![class3.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/class3.png)

Great!! We are done with our Awesome client, we just implemented a decoupled and reusable model that allow us to build custom blocks for each common requirement, and in case that we need to use a common functionality for all clients we can extend BusinessTasks.Commons just like we did with the IT Security requirement.

Now, as testing purposes you can replicate the same library for Great client, and adjust the logic.

At this point we have three libraries: BusinessTasks.Commons, BusinessTasks.Awesome, and BusinessTasks.Great, let’s put them together in a console application and then we are going to instantiate SubmitForApproval for BusinessTasks.Awesome and BusinessTasks.Great libraries.

![console.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/console.png)

Output:

![output.png](https://raw.github.com/rcervantes-dev/strategy-pattern-in-csharp/master/images/output.png)
