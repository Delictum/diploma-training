Var
  t: text;
  j, i, k, n: integer;
  mas: array [1..300] of longint;
  F, z, o, buf: string;

Begin
  assign(t, 'choose.out.txt');
  rewrite(t);
  close(t);
  
  assign(t, 'choose.in.txt');
  reset(t);
  readln(t, n);
  close(t);
  
  for j := 1 to n do 
    mas[j] := 0;    
  mas[1] := 2;
  for j := 2 to n do
  begin
    if j - 2 >= 2 then
      mas[j] := mas[j - 1] * 2 - mas[j - 3]
    else
    if (j - 2 = 0) or (j - 2 = 1) then
      mas[j] := mas[j - 1] * 2 - 1
    else
      mas[j] := mas[j - 1] * 2;
  end;  
  writeln('Общее число вариаций = ', mas[n]);
  
  assign(t, 'choose.out.txt');
  Append(t);
  writeln(t, mas[n]);
  close(t);
  
  z := '0';
  o := '1';
  F := z * n;
  k := Length(F) - 1;
  F := F + (z * k + o);
  F := F + o + (z * k);
  for i := n * 3 to mas[n] * n - 1 do
    begin
      if F[i] = '0' then
        F := F + o
      else 
        F := F + z;
    end;        
    for i := Length(F) div n downto 1 do
      Insert(' ', F, n * i + 1);
    Write(F);
    
  assign(t, 'choose.out.txt');
  Append(t);
  writeln(t, F);
  close(t);
End.