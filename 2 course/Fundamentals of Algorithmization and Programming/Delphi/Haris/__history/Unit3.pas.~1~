unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm3 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Button1: TButton;
    Label1: TLabel;
    Label2: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;

implementation

{$R *.dfm}

uses Unit1;


procedure TForm3.Button1Click(Sender: TObject);
var k: integer;
us: boolean;
begin
  us:=true;
  if (edit1.Text='') or (edit2.Text='') then
    begin
      showMessage('Fill out the field');
    end
  else
    begin
      for k := 1 to 10 do
      if aks[k].name=edit1.text then
          begin
            if us=true then
              begin
                showMessage('This login is already in use');
                us:=false;
              end;
          end
      else
        begin
          aks[k].name:=edit1.Text;
          aks[k].pass:=edit2.Text;
          Form3.Hide;
          Form1.Show;
        end;
    end;
end;

end.
