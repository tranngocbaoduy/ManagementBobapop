# Management Bobapop
--------------------------------------------------------------------------------
This app'll help you in manage a bobapop shop. Thank for all 

***Get program***
```
git clone https://github.com/tranngocbaoduy/ManagementBobapop.git
```

**How to set up program.**


Step 1: After open folder, you create a new database named QLTS (must be named QLTS). Then, you restore file availible QLTS.bak to database QLTS.


Step 2: Open the project. In your right, you’ll see a folder Model. Double click to open it, then you **_delete_** file Model1.edmx.


Step 3: After that, you double click in QLTS and add new item, choose Data and add ADO.NET Entity Data Model named default is Model1. After you click add, the project show a table, click Next and click New Connection. Fill your server name and choose your database QLTS. Click OK. It’ll show you a name such as QLTSEntities. You should **copy** this name, click Next, choose table and click Finish.


Step 4: Wait a minutes, the project show a few table with a relationship. In a corner of window, you’ll see a simple like SAVE ALL, click it and wait for a moment. After finish, it’ll generate a named file is Model1.edmx.


Step 5: Double click it, click Model1.tt. You’ll see file NGUYENLIEU.cs and NHACUNGCAP.cs. In the folder project which I give you, open it and get 2 file NGUYENLIEU.cs and NHACUNGCAP.cs copy all into 2 file just be generated.


Step 6: In the right, you also see the folder DBConnection. Open it, and open file DataProvider.cs. At row 29 and 33, you’ll delete name QLTSEntities current and fill the name which you copied a moment ago. And Save All


Step 7: If you are sure you have followed the steps above, let start project.
