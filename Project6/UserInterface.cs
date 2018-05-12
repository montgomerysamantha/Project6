using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// The User Interface class, which handles the GUI design and gets
/// input from the user. Also has a click event for the "Find
/// Prime Path" button.
/// </summary>
namespace Project6
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The click event for finding the prime path between
        /// the two primes given by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindPrimePath_Click(object sender, EventArgs e)
        {
            string str1 = uxFirstPrimeBox.Text; //the first prime the user entered
            string str2 = uxSecondPrimeBox.Text; // the second prime
            
            //checking that the inputs are all digits or a '-' (negative sign) character
            //no commas
            if (!Regex.IsMatch(str1, "^[0-9-,]*$") || !Regex.IsMatch(str2, "^[0-9-,]*$"))
            {
                MessageBox.Show("Error: Inputs must be integers");
                uxFirstPrimeBox.Text = "";
                uxSecondPrimeBox.Text = "";
                return;
            }

            if (str1.Contains(",")) //delete the commas in str1 so it doesn't mess up our parsing
            {
                str1 = str1.Replace(",", "");
            }

            if (str2.Contains(",")) //delete the commas in str2 so it doesn't mess up our parsing
            {
                str2 = str2.Replace(",", "");
            }

            //now safe to convert them to ints
            int lower = Convert.ToInt32(str1);
            int upper = Convert.ToInt32(str2);
            int digits = Convert.ToInt32(uxDigitsBox.Value);

            //checking if the numbers entered are negative
            if (lower <= 0 || upper <= 0)
            {
                MessageBox.Show("Error: Inputs must be positive");
                return;
            }

            //checking if the length of the numbers doesn't match the selected digits from the NumericUpDown
            if (str1.Length != digits || str2.Length != digits)
            {
                MessageBox.Show("Error: Inputs must match the selected digits");
                return;
            }

            //making sure both of the numbers are prime
            if (!isPrime(lower) || !isPrime(upper))
            {
                MessageBox.Show("Error: Inputs must be prime");
                return;
            }

            //changing lower if the user put a larger number for "First Prime" 
            if (lower > upper)
            {
                int temp = lower;
                lower = upper;
                upper = temp;
            }

            //making the sieve to hold our primes that we generate
            SieveList sieve = new SieveList();

            //formatting of the primes, trimming the extras
            sieve.BuildList(upper);
            sieve.FindPrimes();
            sieve.TrimList(lower); //getting rid of the extra primes below the lower bound (we don't need them)

            //making our graph of primes
            Graph<int> g = new Graph<int>();

            //adding each prime to the graph as a node
            foreach (int num in sieve)
            {
                g.AddNode(num);
            }

            List<int> list = g.Nodes; //get list of all of the nodes in g

            //for each number in the list
            for (int i = 0; i < list.Count; i++)
            {
                //for each of the other numbers in the list
                for (int j = 0; j < list.Count; j++)
                {
                    // if the indices don't match
                    if (i != j)
                    {
                        //get out the numbers we're comparing
                        int num1 = list[i];
                        int num2 = list[j];

                        //check if differ by one, if so, add an edge between the two numbers
                        if (DifferByOne(num1.ToString(), num2.ToString()))
                        {
                            g.AddEdge(num1, num2, 1);
                            g.AddEdge(num2, num1, 1);
                        }
                    }
                }
            }

            //using Breadth First Search to generate a path between the two primes
            //supplied by the user
            List<int> path = g.BFS(lower, upper);

            //updating the text box with the path
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < path.Count; i++)
            {
                sb.Append(path[i] + Environment.NewLine);
            }
            uxTextBox.Text = sb.ToString();
        }

        /// <summary>
        /// Takes in two strings (which are really numbers)
        /// and starts a counter off at 0. If it finds a 
        /// different character while looping through each
        /// char in the respective strings, it increments the
        /// count. If count gets bigger than 1, the function
        /// returns false (because the strings are different
        /// by more than one char). Otherwise, it makes it through
        /// the strings and then checks if count == 1 (what we want)
        /// and returns true. If the strings are the same and the 
        /// count is 0, then it returns false (we don't want the
        /// same strings).
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>true if the strings are different by one char</returns>
        public bool DifferByOne(string str1, string str2)
        {
            int count = 0; //count of how many different characters we've found so far
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    count++; //if the letters don't match update the count
                }

                if (count > 1) return false;
            }

            if (count == 1) return true;
            return false;
        }

        /// <summary>
        /// Function for checking if a number is prime.
        /// This is called on the two user supplied numbers
        /// to check their prime status.
        /// </summary>
        /// <param name="n">The number we are checking</param>
        /// <returns>true if the number is prime</returns>
        public bool isPrime(int n)
        {
            if (n <= 1) return false; // 0 and 1 are not prime
            if (n <= 3) return true; //however 2 and 3 are prime

            if (n % 2 == 0 || n % 3 == 0) return false; //common factors to speed return up, if it meets these conditions we know it's not prime

            for (int i = 5; i*i <= n; i = i + 6) //up until the value of the number we are checking
            {
                if (n % i == 0 || n % (i + 2) == 0) return false; //if it has a factor, it's not prime
            }
            return true; //we've made it this far without finding any factors, so we know the number is prime!
        }
    }
}
