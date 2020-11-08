program lab1;
 
type
  {��� �������� ������.}
  TData = Integer;
  {���, ����������� ��������� �� �������.}
  TPElem = ^TElem;
  {���, ����������� ������� ������.}
  TElem = record
    Data : TData;   {�������� ������ ��������.}
    PNext : TPElem; {��������� �� ��������� �������.}
  end;
  {���, ����������� ������.}
  TDList = record
    PFirst, PLast : TPElem; {��������� �� ������ � �� ��������� �������� ������.}
  end;
 
{��������� ������������� ������.}
procedure Init(var aL : TDList);
begin
  aL.PFirst := nil;
  aL.PLast := nil;
end;
 
{������������ ������, ������� ��� ��������� ������ � �������������.}
procedure LFree(var aL : TDList);
var
  P, PDel : TPElem;
begin
  P := aL.PFirst;  {��������� �� ������ ������� ������.}
  while P <> nil do
  begin
    PDel := P;     {���������� ��������� �� ������� �������.}
    P := P^.PNext; {�������� ��������� �� ��������� �������.}
    Dispose(PDel); {����������� ������, ������� ������� ��������� ������.}
  end;
  Init(aL);
end;
 
{���������� �������� � ����� ������.}
procedure Add(var aL : TDList; const aData : TData);
var
  P : TPElem;
begin
  New(P);           {�������� ������� ��� ��������.}
  P^.Data := aData; {���������� ������.}
  P^.PNext := nil;  {�������� ��������� �� ��������� �������.}
  if aL.PFirst = nil then {���� ������ ����, �� ����� ������� ���������� ������ ��������� ������.}
    aL.PFirst := P
  else {���� ������ ��������, �� ����� ������� ����������� � ���������� �������� ������.}
    aL.PLast^.PNext := P;
  aL.PLast := P; {����� ������� ���������� ��������� ��������� ������.}
end;
 
{���������� ������.}
procedure LWriteln(const aL : TDList);
var
  P : TPElem;
begin
  P := aL.PFirst; {��������� �� ������ ������� ������.}
  if P <> nil then
  repeat
    if P <> aL.PFirst then {���� ������� �� ������ � ������, �� ������ ����� ��� �������.}
      Write(', ');
    Write(P^.Data); {������������� ������ �������� ��������.}
    P := P^.PNext;  {�������� ��������� �� ��������� �������.}
  until P = nil
  else
    Write('������ ����.');
  Writeln;
end;
 
{������������ �������� aP^.PNext �� ������� ����� ���������� aPP � aPP^.PNext.}
procedure Recomb(var aL : TDList; var aP, aPP : TPElem);
var
  P : TPElem;
begin
   P := aP^.PNext; {��������� �� �������, ������� ����� ������������.}
  if aPP = nil then {������� ����� ������ ���������.}
  begin
    aP^.PNext := P^.PNext;
    P^.PNext := aL.PFirst;
    aL.PFirst := P;
  end
  else                {������� ����� ����������.}
  begin
    aP^.PNext := P^.PNext;
    P^.PNext := aPP^.PNext;
    aPP^.PNext := P;
  end;
end;
 
{���������� ����������������� ������ �� ����������� ������� �������.}
procedure SortAsc(var aL : TDList);
var
  P1, P2, PP1, PP2 : TPElem;
begin
  {���� ������ ���� ��� �������� ������ ���� �������, �� �������.}
  if aL.PFirst = aL.PLast then
    Exit;
 
  P1 := aL.PFirst; {��������� �� ���������� �������.}
  P2 := P1^.PNext; {��������� �� ������� �������.}
  while P2 <> nil do {������� ��������� ������, ������� �� ������� ��������.}
  begin
    {����� ����� ������� � ��� ��������������� ����� ������.}
    PP1 := nil;       {��������� �� ���������� �������.}
    PP2 := aL.PFirst; {��������� �� ������� �������.}
    while PP2^.Data > P2^.Data do {�������������� ������� "(PP2 <> P2) and" ����� ����� �� ������������.}
    begin
      PP1 := PP2;
      PP2 := PP2^.PNext;
    end;
    {������������.}
    if PP1 <> P1 then {���� ����� ������� ���������� �� ������� �������, �� ��������� ������������.}
      Recomb(aL, P1, PP1)
    else
      P1 := P2;
    P2 := P1^.PNext; {�������� ��������� �� ��������� �������.}
  end;
end;
 
var
  L : TDList;
  Data : TData;
  i, an, a1 : Integer;
  S : String;
  
begin
  Init(L); {��������� ������������� ������.}
 
  repeat             
    {������ ������.}
    Write('������� ���������� ���������: ');
    Readln(an);
    for i := a1 to an do
    begin
      Write('������� N ', i, ': ');
      Readln(Data);
      Add(L, Data);
    end;
    Writeln('����� ������:');
    LWriteln(L);
 
    SortAsc(L); {���������� ������ �� �����������.}
    Writeln('������ ����� ����������:');
    LWriteln(L);
 
    {������������ ������, ������� ��� ��������� ������.}
    LFree(L);
    Writeln('������, ���������� ��� ������, �����������.');
    Readln(S);
  until S <> '';
end.