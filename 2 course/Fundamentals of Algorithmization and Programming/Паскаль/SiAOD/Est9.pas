const
alphabet : string[5] = '12345';
var
b : array [1..100] of byte ;
i, j, k : byte;

Procedure SwapB(i,k:byte);
var x : byte;
begin
x:=B[i]; B[i]:=B[k]; B[k]:=x;
end;

Procedure WriteB;
var i: byte;
begin
for i:=1 to 4 do 
  write(alphabet[b[i]]);
writeln;
end;

begin
for i:=1 to 4 do 
  b[i]:=i;
WriteB;
while (true) do
  begin
    i:=4;
    while (i>0) and (B[i]>=B[i+1]) do
      i:=i-1;
    if i=0 then exit;
    for j:=i+1 to 4 do
      if (B[j]>B[i]) then K:=j;
    SwapB(i,k);
    for j:=i+1 to (i+ ((5-i) div 2))do
      SwapB(j,5+i-j);
    writeB;
  end;
end.