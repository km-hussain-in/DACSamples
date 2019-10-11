Imports Greeting

Module Program

	Sub Main()
		Dim name As String = InputBox("What is your name?")
		Dim greeter As New Greeter(True)
		MsgBox(greeter.Greet(name))
	End Sub

End Module
