select * from Orders

insert into Orders(CustomerName, CustomerAddress, Phone, OrderDate, 
ShippedDate, Note) output inserted.OrderID
 values ('', '', '', '', '', '')

 insert into Contact values('name', 'nam@gmail.com', 'phone', 'good')

 delete from Contact
select * from OrderDetail