using UnityEngine;

public class ClassDefinitionExploration : MonoBehaviour
{
    //This lesson covers these keywords: new, class, and struct 
    void Start()
    {
        #region What does new actually mean?
        
        // When students first see C#, they often learn object creation like this
        Person fred;            //defines the variable
        fred = new Person();    //creates the value (uses the default constructor, but you can use any of its constructors)
        fred.name = "fred";     //sets the value of a variable contained in the class
        
        //Or shortcut to one line
        Person rodgers = new Person("rodgers");  //defines, creates, and uses a constructor to set the value
        
        Debug.Log(fred);
        Debug.Log(rodgers);
        
        //Use new when you want to explicitly create and initialize a new instance of a type.

        #region There are shorter ways, but not helpful for learning

        Person person = new();  //this doesnt help you learn, but im showing you so if you see it, you understand it.
        
        #endregion
        
        #endregion

        #region When don't we use new?
        
        //base types do not need to have new
        int number = 0;
        string text = "Text";
        
        //this is because the value comes from using a "literal"
        
        //You also don't use new when assinging an object that already exists
        Person first = new Person();    //creates a new value
        Person second = first;          //does not create another Person
        
        //now both first and second point to the same value;
        
        
        /*
         
          So the question isn't:

            “Does this variable need new?”

          A better question is:

            “Am I creating a new value here, or am I receiving a value that already exists?”
            
         */
        
        
        #endregion

        #region Now let's look at some "Tricky" examples

        //This should now look understanble
        Vector3 direction = new Vector3();
        
        // But why not new here?
        Vector3 rightDirection = Vector3.right;

        //Making a new gameobject looks familiar
        GameObject go = new GameObject();

        //making a new component looks different
        go.AddComponent<Rigidbody2D>();
        
        #endregion

        #region Class Examples


        Player player1 = new Player();
        player1.Name = "Joe";
        player1.Score = 100;

        Player player2 = player1;
        player2.Score = 200;
        
        Debug.Log(player1.Score);   //Outputs 200
        
        /*
         Conceptually:

            player1 ──┐
                      ├──> Player { Score = 200 }
            player2 ──┘
          
        Assigning a class variable usually copies the reference, not the entire object.
        That's one of the defining behaviors of classes in C#.
        */

        #endregion
        
        #region Struct Examples

        // we still use new
        Point point1 = new Point();
        point1.x = 10;
        point1.y = 20;
        
        //But watch what happens when we assign it

        Point point2 = point1;
        point2.x = 50;
        Debug.Log(point1.x);        //outputs 10
        
        // Unlike a class, assigning a struct copies the value
        /*
            point1 ──> Point { x = 10, y = 20 }
                    
            point2 ──> Point { x = 50, y = 20 } 
        */


        #region Do structs need new?

        //you can do this, but you dont need too...
        int myIntNumber = new int();                    //completely valid

        //for your own structs, new is useful when you want a constructor-based initialization, like...
        Point newPoint = new Point(10, 20);

        Point example;
        example.x = 10;

        //new asks C# to create and initialize a new instance by invoking the type's construction rules.

        #endregion

        #endregion
    }

    
    
    // class defines a reference type
    private class Person
    {
        public string name;
        
        public Person()
        {
            name = "";
        }

        public Person(string firstName)
        {
            name = firstName;
        }

        public override string ToString()
        {
            return name;
        }
    }

    private class Player
    {
        public string Name;
        public int Score;
    }
    
    // struct defines a value type
    private struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}


