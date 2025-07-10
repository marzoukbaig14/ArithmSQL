
using Microsoft.Data.SqlClient;


namespace VeryLongIntCalculator
{
    public partial class Form1 : Form
    {
        // connection stirng 
        private const string ConnectionString = "Server=DESKTOP-S7ECFH7\\SQLEXPRESS;Database=VeryLongIntCalculatorDB;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // obtaining inputs from form
            string num1 = InputInt1.Text;
            string num2 = InputInt2.Text;
            string operation = OpBox.SelectedItem?.ToString(); // optionals to prevents crash

            // check if null input
            if (string.IsNullOrEmpty(num1) ||string.IsNullOrEmpty(num2) ||
                string.IsNullOrEmpty(operation))
            {
                MessageBox.Show("Please enter both numbers and select operation");
                return;
            }

            if (!IsValidNumber(num1) || !IsValidNumber(num2))
            {
                MessageBox.Show("Please enter digits only.");
                return;
            }
            // Check if the calculation already exists in the database
            string result = LoadFromDatabase(num1, num2, operation);
            if (result != null)
            {
                ResultLabel.Text = $"Result (loaded from DB): {result}";
                return;
            }

            // Perform the calculation using VeryLongInt class
            VeryLongInt a = new VeryLongInt(num1);
            VeryLongInt b = new VeryLongInt(num2);
            VeryLongInt resultNumber;

            if (operation == "+")
            {
                resultNumber = a + b;
            }
            else if (operation == "*")
            {
                resultNumber = a * b;
            }
            else
            {
                MessageBox.Show("Invalid operation selected.");
                return;
            }

            // Display the result
            ResultLabel.Text = $"Result: {resultNumber}";

            // Save the result to the database
            SaveToDatabase(num1, num2, operation, resultNumber.ToString());
        }

        // Load a calculation from the database 
        private string LoadFromDatabase(string num1, string num2, string operation)
        {   
            // query selects Result from the Calculations table where rows have numbers and operator equal to our inputs
            string query = "SELECT Result FROM Calculations WHERE Int1 = @Int1 AND Int2 = @Int2 AND Operator = @Operator";

            // making sql connection object, using statment used to safely close after accessing
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {   
                // adding respective parameters and args
                command.Parameters.AddWithValue("@Int1", num1);
                command.Parameters.AddWithValue("@Int2", num2);
                command.Parameters.AddWithValue("@Operator", operation);

                connection.Open();
                object result = command.ExecuteScalar();
                return result?.ToString();
            }
        }

        // Save a calculation to the database
        private void SaveToDatabase(string num1, string num2, string operation, string result)
        {
            string query = "INSERT INTO Calculations (Int1, Int2, Operator, Result) VALUES (@Int1, @Int2, @Operator, @Result)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Int1", num1);
                command.Parameters.AddWithValue("@Int2", num2);
                command.Parameters.AddWithValue("@Operator", operation);




































































































































































































































































                command.Parameters.AddWithValue("@Result", result);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Helper method to check if a string contains only digits
        private bool IsValidNumber(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
