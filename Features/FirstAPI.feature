Feature: First API tests

Scenario: Simple GET scenario
	When I send "GET" request
	Then I should get response with 200 code

Scenario: Simple POST scenario
	When I send "POST" request
	Then I should get response with 201 code

Scenario Outline: Positive CRUD scenario for Rocker API
	When I send "POST" request
	Then I should get response with 201 code
		And Response should contain new Id
	When I send "GET" request
	Then I should get response with 200 code
		And Response should contain instance with given Id
	When I send "PUT" request with "<name>" and "<band>" with given Id
	Then I should get response with 200 code
	When I send "GET" request with given Id
	Then I should get response with 200 code
		And Response should contain only an instance with "<name>", "<band>" and given Id
	When I send "PATCH" request with "<band2>" with given Id
	Then I should get response with 200 code
	When I send "GET" request with given Id
	Then I should get response with 200 code
		And Response should contain only an instance with "<name>", "<band2>" and given Id
	When I send "DELETE" request with given Id
	Then I should get response with 200 code
	When I send "GET" request with given Id
	Then I should get response with 404 code
	When I send "GET" request
	Then I should get response with 200 code
		And Response should not contain instance with given Id

	Examples:
		| name				| band		| band2		|
		| Kai Hansen		| Helloween	| Gamma Ray	|
		| Michael Schenker	| Scorpions	| MSG		|
		| Doro Pesch		| Warlock	| Doro		|