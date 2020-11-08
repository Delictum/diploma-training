unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.Menus, Vcl.StdCtrls, Vcl.ComCtrls;

type
  TForm1 = class(TForm)
    RichEdit1: TRichEdit;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    N4: TMenuItem;
    N5: TMenuItem;
    N6: TMenuItem;
    N7: TMenuItem;
    N8: TMenuItem;
    N9: TMenuItem;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    FontDialog1: TFontDialog;
    N10: TMenuItem;
    procedure N2Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure N6Click(Sender: TObject);
    procedure N7Click(Sender: TObject);
    procedure N9Click(Sender: TObject);
    procedure N10Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.N10Click(Sender: TObject);
begin
richedit1.Undo;
end;

procedure TForm1.N2Click(Sender: TObject);
begin
if opendialog1.Execute then
richedit1.Lines.LoadFromFile(opendialog1.FileName);
end;

procedure TForm1.N3Click(Sender: TObject);
begin
if savedialog1.Execute then
richedit1.Lines.SaveToFile(Savedialog1.FileName);
end;

procedure TForm1.N4Click(Sender: TObject);
begin
Form1.Close;
end;

procedure TForm1.N6Click(Sender: TObject);
begin
if fontdialog1.Execute then
   richedit1.SelAttributes.Assign(fontdialog1.Font);
   richedit1.SetFocus;
end;

procedure TForm1.N7Click(Sender: TObject);
begin
richedit1.Lines.Clear;
end;

procedure TForm1.N9Click(Sender: TObject);
begin
showmessage('—оздатель данной программы —кор€бкин јртЄм ¬алерьевич (Volga)');
end;

end.
