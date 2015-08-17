using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Calculator : MonoBehaviour {

	//For displaying the current value
	public Text m_CalculatorDisplay;

	//For displaying the calculation
	public Text m_CalculationDisplay;

	//Display for the current number
	private string currentNumber = "0";
	//The max number of digits allowed
	private int maxAllowedDigits = 12;
	//Is the value first in
	private bool isFirst = true;
	//Should the screen be cleared
	private bool clearScreen = false;
	//The number of registers for performing calulations against eachother
	private float[] operationRegs = new float[2];

	private bool clearAfterPress = false;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		this.ClearCalculator();
	}

	/// <summary>
	/// Clears the calculator.
	/// </summary>
	public void ClearCalculator() {
		isFirst = true;
		clearScreen = true;
		currentNumber = "0";

		for(int i = 0; i < operationRegs.Length; i++) {
			operationRegs[i] = 0;
		}

		m_CalculationDisplay.text = "";

		this.UpdateCalculatorDisplay();
	}

	/// <summary>
	/// Gets the calculator input.
	/// </summary>
	/// <param name="calcInput">Calculate input.</param>
	public void GetCalculatorInput(string calcInput) {

		if(clearAfterPress) {
			this.ClearCalculator();
			clearAfterPress = false;
		}

		switch(calcInput) {
		case "0":
			this.AppendNumber(calcInput);
			break;
		case "1":
			this.AppendNumber(calcInput);
			break;
		case "2":
			this.AppendNumber(calcInput);
			break;
		case "3":
			this.AppendNumber(calcInput);
			break;
		case "4":
			this.AppendNumber(calcInput);
			break;
		case "5":
			this.AppendNumber(calcInput);
			break;
		case "6":
			this.AppendNumber(calcInput);
			break;
		case "7":
			this.AppendNumber(calcInput);
			break;
		case "8":
			this.AppendNumber(calcInput);
			break;
		case "9":
			this.AppendNumber(calcInput);
			break;
		case "C":
			this.ClearCalculator();
			this.AppendNumber("0");
			break;
		case ".":
			if(!currentNumber.Contains(".") || clearScreen) {
				this.AppendNumber(calcInput);
			}
			break;
		case "(":
			this.AppendNumber("(");
			break;
		case ")":
			this.AppendNumber(")");
			break;
		case "+":
			this.AppendNumber("+");
			break;
		case "-":
			this.AppendNumber("-");
			break;
		case "x":
			this.AppendNumber("*");
			break;
		case "/":
			this.AppendNumber("/");
			break;
		case "enter":
			this.CalculateResult();
			break;
		}
	}

	/// <summary>
	/// Calculates the result.
	/// </summary>
	public void CalculateResult() {
		m_CalculationDisplay.text = currentNumber;
		
		currentNumber = "" + this.Evaluate(currentNumber);
		this.UpdateCalculatorDisplay();

		clearAfterPress = true;
	}
	
	/// <summary>
	/// Evaluate the specified expression.
	/// </summary>
	/// <param name="expression">Expression.</param>
	public double Evaluate(string expression)
	{
		var doc = new System.Xml.XPath.XPathDocument(new System.IO.StringReader("<r/>"));
		var nav = doc.CreateNavigator();
		var newString = expression;
		newString = (new System.Text.RegularExpressions.Regex(@"([\+\-\*])")).Replace(newString, " ${1} ");
		newString = newString.Replace("/", " div ").Replace("%", " mod ");
		
		double result = (double)nav.Evaluate("number(" + newString + ")");
		
		return result;
	} 

	/// <summary>
	/// Stores the current number.
	/// </summary>
	/// <param name="number">Number.</param>
	private void StoreCurrentNumber(int number) {
		operationRegs[number] = float.Parse(currentNumber);
	}

	/// <summary>
	/// Operations the chosen.
	/// </summary>
	/// <param name="aOperator">A operator.</param>
	private void OperationChosen(string aOperator) {
		StoreCurrentNumber(0);
		isFirst = false;
		clearScreen = true;
	}

	/// <summary>
	/// Appends the number.
	/// </summary>
	/// <param name="numString">Number string.</param>
	private void AppendNumber(string numString) {
		if((currentNumber == "0") || clearScreen) {
			currentNumber = (numString == ".") ? "0." : numString;
		}
		else {
			if(currentNumber.Length < maxAllowedDigits) {
				currentNumber += numString;
			}
		}

		if(clearScreen) {
			clearScreen = false;
		}

		this.UpdateCalculatorDisplay();

		StoreCurrentNumber(isFirst ? 0 : 1);
	}

	/// <summary>
	/// Updates the calculator display.
	/// </summary>
	private void UpdateCalculatorDisplay() {
		m_CalculatorDisplay.text = currentNumber;
	}
}
