const
 alphabet : string[26] = '12345678';
 nv=5; nv1=100;
 
type 
 tv=array[1..nv1] of integer;
 
var
 t:text;
 n, kv:integer;
 b : array [1..100] of byte ;
 i,j,k : byte;

 xv,min,max : tv; 
 iv,jv,rv:integer; 

begin

  assign(t,'choose.out.txt');
 rewrite(t);
 close(t);

 assign(t,'choose.in.txt');
reset(t);
readln(t,n,kv);
if n<kv then 
begin
write('Неверно заданы числа: первое число не может быть больше второго');
exit;
end;
close(t);
for i:=1 to N do b[i]:=i;

for jv:=1 to kv do 
 begin 
 max[jv]:=n-jv+1;
 min[jv]:=kv-jv+1;
 xv[jv]:=min[jv] 
 end; 
 
writeln('Сочетания из ',n,' эл-тов по ', kv, ' элементов'); 

while iv<=kv do 
 begin 
 for jv:=kv downto 1 do 
 Begin
 write(xv[jv], ' ');
 assign(t,'choose.out.txt');
 Append(t);
 write(t,xv[jv],' ');
 close(t);
 end;
 
  assign(t,'choose.out.txt');
 Append(t);
 writeln(t,' ');
 close(t);

 writeln;
 rv:=rv+1; iv:=1; 
 while (iv<=kv) and (xv[iv]=max[iv]) do
 iv:=iv+1;
 if iv<=kv then xv[iv]:=xv[iv]+1;
 for jv:=iv-1 downto 1 do 
 begin 
 min[jv]:= xv[jv+1]+1; 
 xv[jv]:= min[jv]; 
 end;
 
 end; 
writeln('Общее число сочетаний равно rv = ', rv);
end.