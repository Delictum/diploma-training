unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Grids, DateUtils;

type
  TForm1 = class(TForm)
    Memo2: TMemo;
    Button2: TButton;
    Button3: TButton;
    Button5: TButton;
    Button1: TButton;
    Memo1: TMemo;
    StringGrid1: TStringGrid;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure StringGrid1KeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  k: integer;
  i2, j2: string;

implementation

{$R *.dfm}

function GetDateFromStr(s : string): string;  // ��������: ��� ������ �������� ��� ������� ������!
begin
  Result := copy(s,5,4);
end;

procedure SaveGrid(Grid: TStringGrid; FileName: string);
var
  f: textfile;
  x, y: integer;
begin
  assignfile(f, Filename);
  rewrite(f);
  writeln(f, grid.colcount);
  writeln(f, grid.rowcount);
  for X := 0 to grid.colcount - 1 do
    for y := 0 to grid.rowcount - 1 do
      writeln(F, grid.cells[x, y]);
  closefile(f);
end;

procedure LoadGrid(Grid: TStringGrid; FileName: string);
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

procedure TForm1.Button1Click(Sender: TObject);
var
  i, j, n: integer;
  j1, i1: string;
  str: string;
begin
  memo2.Clear;
  for i := 1 to StringGrid1.ColCount - 1 do
  begin
    for j := 1 to StringGrid1.RowCount - 1 do
    begin
      if StringGrid1.Cells[i, j] = '' then
      begin
        j1 := inttostr(j);
        i1 := inttostr(i);
        k := 0;
        memo2.Lines.Add('Error in:' + j1 + ' column, ' + i1 + ' line.');
        j1 := '0';
        i1 := '0';
      end
      else k := 1;
    end;
  end;
  if k = 1 then
  begin
    Memo1.Clear;
    memo2.Clear;
    memo2.Lines.Add('Save to file.');
    savegrid(StringGrid1, 'test.txt');
    memo1.Lines.Add('List of decrease in length of service in departments:');
    for i := 1 to StringGrid1.RowCount - 1 do
    begin
      if i > 0 then
        memo1.Lines.Add('');
      memo1.seltext := (StringGrid1.Cells[2, i] + ' ');
    end;
    for n := 0 to StringGrid1.ColCount - 1 do
    begin
      str := memo1.lines[n];
      delete(str, Length(str), 30);
      memo1.lines[n] := str;
    end;
    Memo1.Lines.SaveToFile('������.txt');
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  memo2.Clear;
  memo2.Lines.Add('File open.');
  loadgrid(StringGrid1, 'test.txt');
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  i, j: integer;
begin
  memo1.Clear;
  memo2.Clear;
  for i := 1 to StringGrid1.ColCount - 1 do
    for j := 1 to StringGrid1.RowCount - 1 do
      StringGrid1.Cells[i, j] := '';
  memo2.Lines.Add('Completely cleared.');
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  i, i1, j, c, c1, z: integer;
  v1, v2: double;

begin
memo2.Clear;
 k:=0;
 memo2.Lines.Add('������ ����������� ');
  StringGrid1.RowCount:=StringGrid1.RowCount+1;
  c:=StringGrid1.RowCount;
  c1:=stringgrid1.RowCount;


  for j:=1 to c-1 do
  for i:=1 to c-1 do
    begin
      v1:=StrTofloatDef(StringGrid1.Cells[4, I], 0);
      v2:=StrTofloatDef(StringGrid1.Cells[4, J], 0);
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

procedure TForm1.FormShow(Sender: TObject);
var i,j,n:integer;
begin
StringGrid1.Cells[0,0]:='# ';
StringGrid1.Cells[1,0]:='����� �����';
StringGrid1.Cells[2,0]:='��� ��������';
StringGrid1.Cells[3,0]:='����� ����������';
StringGrid1.Cells[4,0]:='����� ������';

StringGrid1.ColWidths[0] :=25;
StringGrid1.ColWidths[1] :=160;
StringGrid1.ColWidths[2] :=220;
StringGrid1.ColWidths[3] :=220;
for i:=1 to StringGrid1.RowCount-1 do
StringGrid1.Cells[0,i]:=inttostr(i);
end;

procedure TForm1.StringGrid1KeyPress(Sender: TObject; var Key: Char);
begin
if ((StringGrid1.Col = 1) or (StringGrid1.Col = 4)) then
    if not (key in ['0'..'9', ',', '.', #8]) then
      key := #0;
end;

end.
