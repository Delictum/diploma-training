program ferzi;

type
  mas = array [1..15, 1..15] of integer;

var
  a: mas;   
  {�������, ����������� ��������� ��������� �����}
  i, j, n: integer;
  k: longint;
  t: text;
  vyvod: boolean;

procedure Fill_F(x, y: integer; var a: mas);
 {x, y*� ���������� ������� �����}
var
  i, j: integer;
begin
  for i := 1 to n do
  begin
    a[x, i] := 1; {������, ��� ����� ������ �����*����� ����}
    a[i, y] := 1;     {�������, ��� ����� ������ �����*����� ����}
  end;
  i := x - 1;     {��������� � ����� ������� ������ �� ���������}
  j := y - 1;     {�� (x,y)}
  while (i <> 0) and (j <> 0) do
  begin
    a[i, j] := 1;   {�������� ��������� ����� � ����� �� (x,y) }
    dec(i);
    dec(j);
  end;
  i := x + 1;      {��������� � ������ ������ ������ �� ��������� �� (x,y)}
  j := y + 1;
  while (i <> n + 1) and (j <> n + 1) do
  begin
    a[i, j] := 1;    {�������� ��������� ������ � ���� �� (x,y) }
    inc(i);
    inc(j);
  end;
  i := x - 1;      {��������� � ������ ������� ������}
  j := y + 1;
  while (i <> 0) and (j <> n + 1) do
  begin
    a[i, j] := 1;    {�������� ��������� ������ � ����� �� (x,y)}
    dec(i);
    inc(j);
  end;
  i := x + 1;   {��������� � ����� ������ ������ �� (x,y)}
  j := y - 1;
  while (i <> n + 1) and (j <> 0) do
  begin
    a[i, j] := 1;    {�������� ��������� ����� � ���� �� (x,y)}
    inc(i);
    dec(j);
  end;
  a[x, y] := 0;    {������ ����� �� ����� (x,y)}
end;

procedure Set_F(x: integer; a: mas);
{x*� ������, ���� ��������� �����}
var
  i, j: integer;
  b: mas;
begin
  if (x = n + 1) and (vyvod = true) then {���� ��� ����� �����������}
  begin
    for i := 1 to n do       {������� ������� �����������}
    begin
      for j := 1 to n do
        write(a[i, j]:3);
      writeln;
    end;
    writeln;
    vyvod:=false;
  end;

  if x = n + 1 then {���� ��� ����� �����������}
  begin
    for i := 1 to n do       {������� ������� �����������}
    begin
      for j := 1 to n do
        write(t, a[i, j]:3);
      writeln(t);
    end;
    writeln(t);
    inc(k);{���������� ������� ��������� �����������}
  end
  
  else        {� ��������� ������}
    for i := 1 to n do       {���� � ������}
      if a[x, i] = 0 then      {������ ��������� ������}
      begin
        b := a;        {�������� ������� a � ������� b}
        Fill_F(x, i, b);  {������������� ����� � i-� ������� ������ x}
        Set_F(x + 1, b);      {�������� ��������� ������� ����� � ��������� x+1-� ������ ���������� ������� b}
      end;
end;

begin
  writeln('�� 0 ��������� �����, �� 1 ��������� ������. ������ �����������:');
  writeln;
  vyvod:=true;
  assign(t, '15.txt');
  rewrite(t);
  n := 8;
  k := 0;      {���������� ��������� ����������� ����� 0}
  for i := 1 to n do
    for J := 1 to n do
      a[i, j] := 0;       {��� ������ ������� ��������}
  Set_F(1, a);        {�������� ����������� ��������� ��������� ����� (������� ������������� ������� ����� �� ��������� �����)}
  writeln('���-�� ��������� �����������: ', k);    {������� �����*� ����� ��������� �����������}
  close(t);
end.