namespace Programming.Models
{
    public class Car
    {
        public int Increment = 1;

        public string Name;
        
        public int Position;

        public Car(string name, int position)
        {
            Name = name;
            Position= position; 
        }

        public Car()
        {

        }

        public void SetPosition(int position) 
        {
            if (position > 0)
            {
                Position = position;
            }
        }
        public int GetPosition() 
        {
            return Position;
        }   

        public void MoveRight() 
        {
            Position += Increment;
        }

        public void MoveLeft()
        {
            Position -= Increment;
        }

        public void SetIncrement(int increment) 
        {
            Increment = increment;        
        }
    }
}
