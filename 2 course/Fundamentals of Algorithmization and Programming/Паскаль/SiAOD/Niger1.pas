unit Niger1;

interface
 
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

procedure Init(var aL : TDList);
procedure Add(var aL : TDList; const aData : TData);
procedure LWriteln(const aL : TDList);
procedure LFree(var aL : TDList);
implementation

procedure Init(var aL : TDList);
begin
  aL.PFirst := nil;
  aL.PLast := nil;
end;

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

end.
  