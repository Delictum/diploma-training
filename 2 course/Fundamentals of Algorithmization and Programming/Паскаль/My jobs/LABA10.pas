program Est;
var a,s,st,s4,s5:string;
var g,f,h,p,i,k:integer;
begin
Writeln('������� �����������');
Read(a);
write('������� ���� "�": ');
for i:= 1 to length(a) do
begin
if (a[i]='�') or (a[i]='�') then k:=k+1; 
if a[i]='�' then write(i,' ');
if a[i]='�' then write(i,' ');
end;
writeln('. ���������� ���� "�": ',k);
s:='����������� ��������������';
s4:=copy(s,22,3);
writeln('������ �����: ',s4);
s5:=copy(s,23,2)+copy(s,26,1);
writeln('������ �����: ',s5);
insert (s, st, 1);
delete (st,2,1);
delete (st,6,30);
writeln('������ �����: ',st);
end.