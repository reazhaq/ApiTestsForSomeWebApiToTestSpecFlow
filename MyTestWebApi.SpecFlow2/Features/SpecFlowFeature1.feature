Feature: Can call API
	In order to ensure correct value is consumed
	As a user
	I want to validate value returned from api call

Scenario Outline: Can call the API without any error
	Given steady state
	When I pass <value> to the end-point
	Then I see <returnValue> in response

	Examples: 
		| value   | returnValue           |
		| value1  | value1 was the param  |
		| blah    | blah was the param    |
		| hook'em | hook'em was the param |