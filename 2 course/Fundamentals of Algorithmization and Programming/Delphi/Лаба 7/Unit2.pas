unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Grids;

type
  TForm2 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Memo1: TMemo;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Memo2: TMemo;
    Button6: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure StringGrid1KeyPress(Sender: TObject; var Key: Char);
    procedure Button2Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
k:integer;
     i2,j2:string;
  Form2: TForm2;

implementation

{$R *.dfm}
procedure SaveGrid(Grid:TStringGrid;FileName:string);
var
f: textfile;
x, y: integer;
begin
assignfile(f,Filename);
rewrite(f);
writeln(f, grid.colcount);
writeln(f, grid.rowcount);
for X := 0 to grid.colcount - 1 do
for y := 0 to grid.rowcount - 1 do
writeln(F, grid.cells[x, y]);
closefile(f);
end;

procedure TForm2.Button1Click(Sender: TObject);
var
i,j,n: integer;
j1,i1:string;
str:string;
begin
memo2.Clear;
for i:=1 to StringGrid1.ColCount-1 do
 begin
 for j:=1 to StringGrid1.RowCount-1 do
 begin
  if StringGrid1.Cells[j,i]='' then
   begin
   j1:=inttostr(j);
   i1:=inttostr(i);
   k:=0;
   memo2.Lines.Add('������ �:'+j1+' �������, '+i1+' �������');
   j1:='0';
   i1:='0';
  end else k:=1;
 end;
 end;
if k=1 then begin
Memo1.Clear;
memo2.Clear;
memo2.Lines.Add('������ �����������');
savegrid(StringGrid1,'test.txt');
memo1.Lines.Add('������� �� ��������� � ���������:');
for i:=1 to StringGrid1.RowCount-1 do
 begin
 if i>0 then
 memo1.Lines.Add('');
 memo1.seltext:=(StringGrid1.Cells[1,i]+' ');
 end;
 for n:=0 to StringGrid1.ColCount-1 do
  begin
  str:=memo1.lines[n];
  delete(str,Length(str),30);
  memo1.lines[n]:=str;
  end;
 Memo1.Lines.SaveToFile('������.txt');
end;
end;


procedure LoadGrid(Grid:TStringGrid;FileName:string);
var
f: textfile;
temp, x, y: integer;
tempstr: string;
begin
assignfile(f, Filename);
reset(f);
readln(f, temp); // ���������� ���������� �������
grid.colcount := temp;
readln(f, temp); // ���������� ���������� �����
grid.rowcount := temp;
for X := 0 to grid.colcount - 1 do
for y := 0 to grid.rowcount - 1 do
begin
readln(F, tempstr);
grid.cells[x, y] := tempstr; // ���������� ������
end;
closefile(f);
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
loadgrid(StringGrid1,'test.txt');
end;

procedure TForm2.Button3Click(Sender: TObject);
var i,j:integer;
begin
memo1.Clear;
memo2.Clear;
for i:=1 to StringGrid1.ColCount-1 do
for j:=1 to StringGrid1.RowCount-1 do
StringGrid1.Cells[i,j]:='';
end;

procedure TForm2.Button4Click(Sender: TObject);
var i:integer;
begin
StringGrid1.rowCount:=StringGrid1.rowCount+1;
for i:=1 to StringGrid1.RowCount-1 do
StringGrid1.Cells[0,i]:=inttostr(i);
k:=1;
end;

procedure TForm2.Button5Click(Sender: TObject);
var
i,i1,j,c,c1,z:integer;
v1,v2:double;

begin
memo2.Clear;
for i:=1 to StringGrid1.ColCount-1 do
 begin
 for j:=1 to StringGrid1.RowCount-1 do
 begin
  if StringGrid1.Cells[j,i]='' then
   begin
   j2:=inttostr(j);
   i2:=inttostr(i);
   k:=0;
   memo2.Lines.Add('������ �:'+j2+' �������, '+i2+' �������');
  end
  else
  begin
  k:=1;
  end;
 end;
 end;
 if k=1 then
 begin
 k:=0;
 memo2.Lines.Add('������ ����������� ');
  StringGrid1.RowCount:=StringGrid1.RowCount+1;
  c:=StringGrid1.RowCount;
  c1:=stringgrid1.RowCount;
  { for j:=1 to c1-1 do
  for i:=1 to c1-1 do
    begin
      v1:=StrTofloatDef(StringGrid1.Cells[4, I], 0);
      v2:=StrTofloatDef(StringGrid1.Cells[4, J], 0);
      if v1<v2 then
      begin
        StringGrid1.Rows[c]:=StringGrid1.Rows[i];
        StringGrid1.Rows[i]:=StringGrid1.Rows[j];
        StringGrid1.Rows[j]:=StringGrid1.Rows[c];
      end;
    end; }

  for j:=1 to c-1 do
  for i:=1 to c-1 do
    begin
      v1:=StrTofloatDef(StringGrid1.Cells[3, I], 0);
      v2:=StrTofloatDef(StringGrid1.Cells[3, J], 0);
      if v1<v2 then
      begin
        StringGrid1.Rows[c]:=StringGrid1.Rows[i];
        StringGrid1.Rows[i]:=StringGrid1.Rows[j];
        StringGrid1.Rows[j]:=StringGrid1.Rows[c];
      end;
    end;
  StringGrid1.RowCount:= StringGrid1.RowCount-1;
for i1:=1 to StringGrid1.RowCount-1 do
StringGrid1.Cells[0,i1]:=inttostr(i1);
 end;
end;



procedure TForm2.Button6Click(Sender: TObject);
var i,j,k:integer; j2,i2:string;
begin
memo2.Clear;
for i:=1 to StringGrid1.ColCount-1 do
 begin
 for j:=1 to StringGrid1.RowCount-1 do
 begin
  if StringGrid1.Cells[j,i]='' then
   begin
   j2:=inttostr(j);
   i2:=inttostr(i);
   memo2.Lines.Add('������ �:'+j2+' �������, '+i2+' �������');
   j2:='0';
   i2:='0';
  end else k:=1;
 end;
 end;
 if k=1 then begin
   memo2.Clear;
  memo2.Lines.Add('������ �����������');
 end;
end;

procedure TForm2.StringGrid1KeyPress(Sender: TObject; var Key: Char);

begin
 if ((StringGrid1.Col=3) or (StringGrid1.Col=4)) then
  if not (key in ['0'..'9',',','.',#8]) then
    key:=#0;
end;

end.
