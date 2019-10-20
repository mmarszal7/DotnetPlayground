# C# References

**Passing value types:**<br>

- When we pass a ValueType to a method or assign it to a new variable, we are making a COPY.

**Passing reference types:**<br>

- A reference type still has a value – it’s just that the ‘value’ is a memory location where the actual data is
- In this way when passing/assigning referency types their values (memory locations) are copied like in ValueTypes.

---

## 8 scenarious:

So in C# we always have 2^3 = 8 basic scenarios:

- passing value OR reference type
- passing by value OR reference
- changing OR reassigning value inside function

---

```C#
void Caller()
{
	int someType = 5;
	SimpleObject someReferenceType = new SimpleObject(){ Number = 5 };

	Method(o);
}
```

## 1. ValueTypes (**ValueTypes.cs**):

- passing by value:

  - example: void Method(int someType)
  - value/data of 'someType' is copied
  - changes in Method won't be visible for the Caller

- passing by reference:
  - example: void Method(ref int someType)
  - reference to 'someType' is copied
  - changes in Method will visible for the Caller

## 2. ReferenceTypes (**ReferenceTypes.cs**):

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

---

## \* 3. Lists - scenarios:

- List of value types (**ListOfValueTypes.cs**):
  - passing by value AND reference:
    - reassign AND update/add/delete/replace list item

* List of reference types (**ListOfReferenceTypes.cs**):
  - passing by value AND reference:
    - reassign AND update/add/delete/replace list item

---
## Demo presentation - Reference and value types:
1. Why? To understand and summarize data flow.
2. Drawing + Possible scenarios.
3. Copy/Clone - memory management:
	- Which one is used for passing objects to methods (example of Tree objects)?
	- If it is always copy, so how we pass Reference types? Still by value but value = memory address
4. Demo explanation.
5. Always the same question: what will be the result of the function?
6. Biggest problems -> Lists management in UIs (WPF, Blazor)
