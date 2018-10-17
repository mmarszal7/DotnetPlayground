 # C# References
**Passing value types:**<br>
- When we pass a ValueType to a method or assign it to a new variable, we are making a COPY.

**Passing reference types:**<br>
- A reference type still has a value – it’s just that the ‘value’ is a memory location where the actual data is
- In this way when passing/assigning referency types their values (memory locations) are copied like in ValueTypes.

---
### So we have 4 scenarious:
``` C#
void Caller()
{
	int someType = 5;
	SimpleObject someReferenceType = new SimpleObject(){ Number = 5 };

	Method(o);
}
```

### 1. ValueTypes: 
- passing by value:
    - example: void Method(int someType) 
    - value/data of 'someType' is copied
    - changes in Method won't be visible for the Caller

- passing by reference:
    - example: void Method(ref int someType) 
    - reference to 'someType' is copied 
    - changes in Method will visible for the Caller

### 2. ReferenceTypes:
- passing by value:
    - example: void Method(SimpleObject someReferenceType) 
    - value/data (location in memory) of 'someReferenceType' is copied - now both variables point at the same memory location 
    - changes in Method will visible for the Caller
    - reassigning 'someReferenceType' **won't** be visible for the Caller

- passing by reference:
    - example: void Method(ref SimpleObject someReferenceType) 
    - reference to 'someReferenceType' is copied - now both variables point at the same memory location 
    - changes in Method will visible for the Caller
    - reassigning 'someReferenceType' **will** be visible for the Caller
