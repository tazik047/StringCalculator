using System;
using NUnit.Framework;

namespace UnitTestProject1
{
	[TestFixture]
	public class SimpleStringCalculatorTests
	{
		[Test]
		public void Add_Take_EmptyString_Return_0()
		{
			//Arange
			var parameters = "";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(0, result);
		}

		
		[Test]
		public void Add_Take_10_Return_10()
		{
			//Arange
			var parameters = "10";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(10, result);
		}

		[Test]
		public void Add_Take_1_And_2_Return_3()
		{
			//Arange
			var parameters = "1,2";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(3, result);
		}

		[Test]
		public void Add_Take_1_And_2_On_Separate_Lines_Return_3()
		{
			//Arange
			var parameters = "1\n2";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(3, result);
		}

		[Test]
		public void Add_Take_1_And_2_And_3_Separated_By_Comma_And_New_Line_Return_3()
		{
			//Arange
			var parameters = "1\n2,3";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_Take_1_And_2_And_3_Separated_By_Custom_Delimeter_Return_3()
		{
			//Arange
			var parameters = "//[[\n1[[2[[3";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_Take_1_And_2_And_3_Separated_By_Custom_Delimeter_New_Line_Return_3()
		{
			//Arange
			var parameters = "//\n\n1\n2\n3";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_Take_1_And_2_And_3_Separated_By_Custom_Delimeter_Two_New_Line_Return_3()
		{
			//Arange
			var parameters = "//\n\n\n1\n\n2\n\n3";

			//Act
			var result = SimpleStringCalculator.Add(parameters);

			//Assert
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Add_Take_Two_Negative_Number_Throw_ArgumentException()
		{
			//Arange
			var parameters = "1\n-2\n3\n-5";
			var expectedMessage = "negatives not allowed: -2,-5";

			//Act

			//Assert
			Assert.Throws<ArgumentException>(() => SimpleStringCalculator.Add(parameters), expectedMessage);
		}
	}
}
