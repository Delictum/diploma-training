unit Unit7;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Imaging.jpeg,
  Vcl.ExtCtrls, Vcl.Imaging.pngimage;

type
  TFormHelp = class(TForm)
    ListBox1: TListBox;
    ScrollBox1: TScrollBox;
    Image1: TImage;
    Image3: TImage;
    Memo3: TMemo;
    Memo1: TMemo;
    ScrollBox2: TScrollBox;
    ScrollBox3: TScrollBox;
    ScrollBox4: TScrollBox;
    ScrollBox5: TScrollBox;
    ScrollBox6: TScrollBox;
    ScrollBox7: TScrollBox;
    ScrollBox8: TScrollBox;
    ScrollBox9: TScrollBox;
    Label22: TLabel;
    Memo15: TMemo;
    ScrollBox10: TScrollBox;
    Memo16: TMemo;
    procedure ListBox1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormHelp: TFormHelp;

implementation

{$R *.dfm}

uses Unit1;

procedure TFormHelp.ListBox1Click(Sender: TObject);
begin
  case ListBox1.ItemIndex of
    0: begin
        formHelp.ScrollBox1.Visible := true;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    1: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := true;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    2: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := true;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    3: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := true;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
      4: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := true;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    5: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := true;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    6: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := true;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    7: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := true;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    8: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := true;
        formHelp.ScrollBox10.Visible := false;
       end;
  end;
end;

end.
