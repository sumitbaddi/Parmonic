The Single Entry Ledger representation is defined using the following Entity, Aggregate root and value-objects

1. JournalEntry.
	This is defined as an entity/aggregate root to hold the following fields representing a single entry ledger
	* Balance amount
	* Transaction items in a list	
	* A validation for validating a valid debit entry in the single entry ledger for each transaction 


2. JournalEntryLedger
	This is defined to represent each transaction in the single entry ledger and holds the following:
	* Description
	* Transaction Date
	* Transaction type
	* Transaction amount

3. Transaction Type
	* Credit
	* Debit