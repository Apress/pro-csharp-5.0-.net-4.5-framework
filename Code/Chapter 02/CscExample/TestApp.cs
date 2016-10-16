using System;

// Don't need this anymore.
// using System.Windows.Forms;

class TestApp
{
  static void Main()
  {
    Console.WriteLine("Testing! 1, 2, 3");

    // Don't need this anymore either.
    // MessageBox.Show("Hello...");

    // Use the HelloMessage class!
    HelloMessage h = new HelloMessage();
    h.Speak();
  }
}
