program Est;
var a,s,st,s4,s5:string;
var g,f,h,p,i,k:integer;
begin
Writeln('Введите предложение');
Read(a);
write('Позиции букв "и": ');
for i:= 1 to length(a) do
begin
if (a[i]='и') or (a[i]='И') then k:=k+1; 
if a[i]='и' then write(i,' ');
if a[i]='И' then write(i,' ');
end;
writeln('. Количество букв "и": ',k);
s:='Абстрактная инфантильность';
s4:=copy(s,22,3);
writeln('Первое слово: ',s4);
s5:=copy(s,23,2)+copy(s,26,1);
writeln('Второе слово: ',s5);
insert (s, st, 1);
delete (st,2,1);
delete (st,6,30);
writeln('Третее слово: ',st);
end.