unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm5 = class(TForm)
    Button1: TButton;
    ComboBox2: TComboBox;
    ComboBox3: TComboBox;
    ComboBox1: TComboBox;
    procedure Button1Click(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
    procedure ComboBox3Change(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form5: TForm5;

implementation

{$R *.dfm}

uses Unit2;

procedure TForm5.Button1Click(Sender: TObject);
begin
Form5.Hide;
Form2.Show;
end;

procedure TForm5.ComboBox1Change(Sender: TObject);
var i:integer;
begin
  i:=combobox1.ItemIndex;
  case i of
  0: Form2.RichEdit1.Font.Color := clBlack;
  1: Form2.RichEdit1.Font.Color := clGray;
  2: Form2.RichEdit1.Font.Color := clGreen;
  3: Form2.RichEdit1.Font.Color := clYellow;
  4: Form2.RichEdit1.Font.Color := clRed;
  end;
end;

procedure TForm5.ComboBox2Change(Sender: TObject);
var i:integer;
begin
  i:=combobox2.ItemIndex;
  case i of
  0: Form2.RichEdit1.Font.Style := [ ];
  1: Form2.RichEdit1.Font.Style := [fsBold];
  2: Form2.RichEdit1.Font.Style := [fsItalic];
  3: Form2.RichEdit1.Font.Style := [fsBold, fsItalic];
  4: Form2.RichEdit1.Font.Style := [fsUnderline];
  end;
end;

procedure TForm5.ComboBox3Change(Sender: TObject);
var i:integer;
begin
  i:=combobox3.ItemIndex;
  case i of
  0: Form2.RichEdit1.Font.Size := 8;
  1: Form2.RichEdit1.Font.Size := 10;
  2: Form2.RichEdit1.Font.Size := 12;
  3: Form2.RichEdit1.Font.Size := 18;
  end;
end;

end.
