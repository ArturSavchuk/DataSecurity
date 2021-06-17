#  MY DOCUMENTATION #
##  <a id="namespace-list" />  Namespaces ##

 | Name | Summary | 
 | ------ | --------- | 
 | [lab4](#n-lab4__6td7zr) |  | 

##  <a id="type-list" />  Types ##

 | Name | Modifier | Kind | Summary | 
 | ------ | ---------- | ------ | --------- | 
 | [Argon2](#t-lab4.argon2__3kceqw) | internal | Class |  | 
 | [Bcrypt](#t-lab4.bcrypt__1fnxkz5) | internal | Class |  | 
 | [Md5](#t-lab4.md5__cwprsf) | internal | Class |  | 
 | [PasswordGenerator](#t-lab4.passwordgenerator__187env) | internal | Class |  | 
 | [Program](#t-lab4.program__5mnw3b) | internal | Class |  | 

Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="n-lab4__6td7zr" />  lab4 Namespace ##
###  Classes ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [Argon2](#t-lab4.argon2__3kceqw) | internal |  | 
 | [Bcrypt](#t-lab4.bcrypt__1fnxkz5) | internal |  | 
 | [Md5](#t-lab4.md5__cwprsf) | internal |  | 
 | [PasswordGenerator](#t-lab4.passwordgenerator__187env) | internal |  | 
 | [Program](#t-lab4.program__5mnw3b) | internal |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="t-lab4.argon2__3kceqw" />  Argon2 Class ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Sources: Program.cs</small>



```csharp
internal class Argon2
```

Inheritance: <a href="https://docs.microsoft.com/en-us/dotnet/api/system.object" target="_blank" >object</a>           



###  Fields ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [path](#f-lab4.argon2.path__yqg0ox) | public |  | 

 


###  Methods ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [CreateNonce()](#m-lab4.argon2.createnonce__16zgxge) | protected |  | 
 | [HashAndRecordPasswords(List&lt;string&gt;)](#m-lab4.argon2.hashandrecordpasswords_system.collections.generic.list_system.string____1qxr13v) | public |  | 
 | [RecordHash(string)](#m-lab4.argon2.recordhash_system.string___1tone6r) | public |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.argon2.path__yqg0ox" />  Argon2.path Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Argon2](#t-lab4.argon2__3kceqw)           
Sources: Program.cs</small>



```csharp
public string path
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.argon2.createnonce__16zgxge" />  Argon2.CreateNonce() Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Argon2](#t-lab4.argon2__3kceqw)           
Sources: Program.cs</small>



```csharp
protected byte[] CreateNonce()
```

<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte" target="_blank" >byte[]</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.argon2.hashandrecordpasswords_system.collections.generic.list_system.string____1qxr13v" />  Argon2.HashAndRecordPasswords(List&lt;string&gt;) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Argon2](#t-lab4.argon2__3kceqw)           
Sources: Program.cs</small>



```csharp
public void HashAndRecordPasswords(List<string> passwords)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1" target="_blank" >List&lt;string&gt;</a> <strong>passwords</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.argon2.recordhash_system.string___1tone6r" />  Argon2.RecordHash(string) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Argon2](#t-lab4.argon2__3kceqw)           
Sources: Program.cs</small>



```csharp
public void RecordHash(string pwdplusnonce)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a> <strong>pwdplusnonce</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="t-lab4.bcrypt__1fnxkz5" />  Bcrypt Class ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Sources: Program.cs</small>



```csharp
internal class Bcrypt
```

Inheritance: <a href="https://docs.microsoft.com/en-us/dotnet/api/system.object" target="_blank" >object</a>           



###  Fields ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [path](#f-lab4.bcrypt.path__1tjpj0q) | public |  | 

 


###  Methods ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [HashAndRecordPasswords(List&lt;string&gt;)](#m-lab4.bcrypt.hashandrecordpasswords_system.collections.generic.list_system.string____tuy41g) | public |  | 
 | [RecordHash(string)](#m-lab4.bcrypt.recordhash_system.string___hbj94a) | public |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.bcrypt.path__1tjpj0q" />  Bcrypt.path Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Bcrypt](#t-lab4.bcrypt__1fnxkz5)           
Sources: Program.cs</small>



```csharp
public string path
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.bcrypt.hashandrecordpasswords_system.collections.generic.list_system.string____tuy41g" />  Bcrypt.HashAndRecordPasswords(List&lt;string&gt;) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Bcrypt](#t-lab4.bcrypt__1fnxkz5)           
Sources: Program.cs</small>



```csharp
public void HashAndRecordPasswords(List<string> passwords)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1" target="_blank" >List&lt;string&gt;</a> <strong>passwords</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.bcrypt.recordhash_system.string___hbj94a" />  Bcrypt.RecordHash(string) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Bcrypt](#t-lab4.bcrypt__1fnxkz5)           
Sources: Program.cs</small>



```csharp
public void RecordHash(string pwdplusnonce)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a> <strong>pwdplusnonce</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="t-lab4.md5__cwprsf" />  Md5 Class ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Sources: Program.cs</small>



```csharp
internal class Md5
```

Inheritance: <a href="https://docs.microsoft.com/en-us/dotnet/api/system.object" target="_blank" >object</a>           



###  Fields ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [path](#f-lab4.md5.path__sravf2) | private |  | 

 


###  Methods ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [CreateNonce()](#m-lab4.md5.createnonce__11g6701) | protected |  | 
 | [HashAndRecordPasswords(List&lt;string&gt;)](#m-lab4.md5.hashandrecordpasswords_system.collections.generic.list_system.string____16l9g7i) | public |  | 
 | [RecordHash(string)](#m-lab4.md5.recordhash_system.string___1ibr5qg) | public |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.md5.path__sravf2" />  Md5.path Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Md5](#t-lab4.md5__cwprsf)           
Sources: Program.cs</small>



```csharp
private string path
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.md5.createnonce__11g6701" />  Md5.CreateNonce() Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Md5](#t-lab4.md5__cwprsf)           
Sources: Program.cs</small>



```csharp
protected byte[] CreateNonce()
```

<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte" target="_blank" >byte[]</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.md5.hashandrecordpasswords_system.collections.generic.list_system.string____16l9g7i" />  Md5.HashAndRecordPasswords(List&lt;string&gt;) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Md5](#t-lab4.md5__cwprsf)           
Sources: Program.cs</small>



```csharp
public void HashAndRecordPasswords(List<string> passwords)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1" target="_blank" >List&lt;string&gt;</a> <strong>passwords</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.md5.recordhash_system.string___1ibr5qg" />  Md5.RecordHash(string) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Md5](#t-lab4.md5__cwprsf)           
Sources: Program.cs</small>



```csharp
public void RecordHash(string pwdplusnonce)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a> <strong>pwdplusnonce</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="t-lab4.passwordgenerator__187env" />  PasswordGenerator Class ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Sources: Program.cs</small>



```csharp
internal class PasswordGenerator
```

Inheritance: <a href="https://docs.microsoft.com/en-us/dotnet/api/system.object" target="_blank" >object</a>           



###  Fields ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [most_common_words](#f-lab4.passwordgenerator.most_common_words__walvmu) | private |  | 
 | [random_persentage](#f-lab4.passwordgenerator.random_persentage__17x5cwb) | private |  | 
 | [top100000passwords](#f-lab4.passwordgenerator.top100000passwords__ewh7a5) | private |  | 
 | [top100000percentage](#f-lab4.passwordgenerator.top100000percentage__1hrtlq5) | private |  | 
 | [top100passwords](#f-lab4.passwordgenerator.top100passwords__jnup5p) | private |  | 
 | [top100percentage](#f-lab4.passwordgenerator.top100percentage__uxldal) | private |  | 

 


###  Constructors ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [PasswordGenerator(int, int, int)](#m-lab4.passwordgenerator.-ctor_system.int32-system.int32-system.int32___1ktusbp) | public |  | 

 


###  Methods ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [ChangeCase(string)](#m-lab4.passwordgenerator.changecase_system.string___1s2p9mh) | private |  | 
 | [GeneratePasswords(int)](#m-lab4.passwordgenerator.generatepasswords_system.int32___1tzft73) | public |  | 
 | [GenHumanLikePassword()](#m-lab4.passwordgenerator.genhumanlikepassword__ggr5l7) | public |  | 
 | [GenRandomPassword(int)](#m-lab4.passwordgenerator.genrandompassword_system.int32___yb5f3o) | private |  | 
 | [ReplaceNumbers(string)](#m-lab4.passwordgenerator.replacenumbers_system.string___1cb4thn) | private |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.most_common_words__walvmu" />  PasswordGenerator.most_common_words Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string[] most_common_words
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string[]</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.random_persentage__17x5cwb" />  PasswordGenerator.random_persentage Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private int random_persentage
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.top100000passwords__ewh7a5" />  PasswordGenerator.top100000passwords Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string[] top100000passwords
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string[]</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.top100000percentage__1hrtlq5" />  PasswordGenerator.top100000percentage Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private int top100000percentage
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.top100passwords__jnup5p" />  PasswordGenerator.top100passwords Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string[] top100passwords
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string[]</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="f-lab4.passwordgenerator.top100percentage__uxldal" />  PasswordGenerator.top100percentage Field ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private int top100percentage
```

<strong>Field value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.-ctor_system.int32-system.int32-system.int32___1ktusbp" />  PasswordGenerator.PasswordGenerator(int, int, int) Constructor ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
public PasswordGenerator(int top100, int top100000, int random)
```

<strong>Constructor parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a> <strong>top100</strong></dt><dd></dd><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a> <strong>top100000</strong></dt><dd></dd><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a> <strong>random</strong></dt><dd></dd></dl>
Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.changecase_system.string___1s2p9mh" />  PasswordGenerator.ChangeCase(string) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string ChangeCase(string pwd)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a> <strong>pwd</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.generatepasswords_system.int32___1tzft73" />  PasswordGenerator.GeneratePasswords(int) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
public List<string> GeneratePasswords(int count)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a> <strong>count</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1" target="_blank" >List&lt;string&gt;</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.genhumanlikepassword__ggr5l7" />  PasswordGenerator.GenHumanLikePassword() Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
public string GenHumanLikePassword()
```

<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.genrandompassword_system.int32___yb5f3o" />  PasswordGenerator.GenRandomPassword(int) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string GenRandomPassword(int length)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32" target="_blank" >int</a> <strong>length</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.passwordgenerator.replacenumbers_system.string___1cb4thn" />  PasswordGenerator.ReplaceNumbers(string) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [PasswordGenerator](#t-lab4.passwordgenerator__187env)           
Sources: Program.cs</small>



```csharp
private string ReplaceNumbers(string str)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a> <strong>str</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="t-lab4.program__5mnw3b" />  Program Class ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Sources: Program.cs</small>



```csharp
internal class Program
```

Inheritance: <a href="https://docs.microsoft.com/en-us/dotnet/api/system.object" target="_blank" >object</a>           



###  Methods ###

 | Name | Modifier | Summary | 
 | ------ | ---------- | --------- | 
 | [Main(string[])](#m-lab4.program.main_system.string_____8bw7dk) | private static |  | 

 


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 


##  <a id="m-lab4.program.main_system.string_____8bw7dk" />  Program.Main(string[]) Method ##
<small>Namespace: [lab4](#n-lab4__6td7zr)           
Assembly: lab4           
Type: [Program](#t-lab4.program__5mnw3b)           
Sources: Program.cs</small>



```csharp
private static void Main(string[] args)
```

<strong>Method parameters</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.string" target="_blank" >string[]</a> <strong>args</strong></dt><dd></dd></dl>
<strong>Return value</strong><dl><dt><a href="https://docs.microsoft.com/en-us/dotnet/api/system.void" target="_blank" >void</a></dt><dd></dd></dl>


Go to [namespaces](doc.md#namespace-list) or [types](doc.md#type-list)


 



