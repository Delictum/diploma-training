unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses Unit2;

procedure TForm1.Button1Click(Sender: TObject);
var i,j,n:integer;
begin
form1.Hide;
form2.show;
form2.StringGrid1.Cells[0,0]:='# ';
form2.StringGrid1.Cells[1,0]:='���';
form2.StringGrid1.Cells[2,0]:='������';
form2.StringGrid1.Cells[3,0]:='������� ����';
form2.StringGrid1.Cells[4,0]:='�����';

form2.StringGrid1.ColWidths[0] :=20;
form2.StringGrid1.ColWidths[1] :=280;
form2.StringGrid1.ColWidths[3] :=180;
for i:=1 to form2.StringGrid1.RowCount-1 do
form2.StringGrid1.Cells[0,i]:=inttostr(i);
end;

end.
