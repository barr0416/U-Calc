using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calculator : MonoBehaviour {

	//For displaying the current value
	public Text m_CalculatorDisplay;

	//Display for the current number
	private string currentNumber = "0";
	//The max number of digits allowed
	private int maxAllowedDigits = 10;
	//Is the value first in
	private bool isFirst = true;
	//Should the screen be cleared
	private bool clearScreen = false;
	//What operation is being performed
	private string currentOperation = "";
	//The number of registers for performing calulations against eachother
	private float[] operationRegs = new float[2];

	private string nullNumberIdentifier = "null";

	/// <summary>
	/// Clears the calculator.
	/// </summary>
	public void ClearCalculator() {
		isFirst = true;
		clearScreen = true;
		currentNumber = "0";
		this.UpdateCalculatorDisplay();
	}

	/// <summary>
	/// Performs the operation.
	/// </summary>
	public void PerformOperation() {
		switch(currentOperation) {
		case "+":
			if(currentNumber != nullNumberIdentifier) {
				currentNumber = (operationRegs[0] + operationRegs[1]).ToString();
			}
			break;
		case "-":
			if(currentNumber != nullNumberIdentifier) {
				currentNumber = (operationRegs[0] - operationRegs[1]).ToString();
			}
			break;
		case "x":
			if(currentNumber != nullNumberIdentifier) {
				currentNumber = (operationRegs[0] * operationRegs[1]).ToString();
			}
			break;
		case "/":
			if(currentNumber != nullNumberIdentifier) {
				//Check to ensure we are not trying to divide by zero before dividing
				currentNumber = (operationRegs[1] != 0) ? (operationRegs[0] / operationRegs[1]).ToString() : nullNumberIdentifier;
			}
			break;
		case "":
			break;
		default:
			Debug.LogError("Invalid or unknown operation: " + currentOperation);
			currentNumber = nullNumberIdentifier;
			break;
		}
		isFirst = true;
		clearScreen = true;
		//Store the current number at the first position
		StoreCurrentNumber(0);

		this.UpdateCalculatorDisplay();
	}

	public void GetCalculatorInput(string calcInput) {
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
			break;
		case ".":
			if(!currentNumber.Contains(".") || clearScreen) {
				this.AppendNumber(calcInput);
			}
			break;
		case "+":
			this.OperationChosen(calcInput);
			break;
		case "-":
			this.OperationChosen(calcInput);
			break;
		case "x":
			this.OperationChosen(calcInput);
			break;
		case "/":
			this.OperationChosen(calcInput);
			break;
		case "enter":
			this.PerformOperation();
			break;
		}
	}

	private void StoreCurrentNumber(int number) {
		operationRegs[number] = float.Parse(currentNumber);
	}

	private void OperationChosen(string aOperator) {
		StoreCurrentNumber(0);
		isFirst = false;
		clearScreen = true;
		currentOperation = aOperator;
	}

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

	private void UpdateCalculatorDisplay() {
		m_CalculatorDisplay.text = currentNumber;
	}

}
