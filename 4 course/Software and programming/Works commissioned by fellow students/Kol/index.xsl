<?xml version="1.0" encoding="ISO-8859-1"?><xsl:stylesheet version="1.0"
                                                           xmlns:xsl="http://www.w3.org/1999/XSL/Transform"><xsl:template match="/">
    <html>
        <body>
            <h2>XSL</h2>
            <table border="1">
                <tr bgcolor="#9acd32">
                    <th align="left">raznovidnost</th>
                    <th align="left">stoim</th>
					<th align="left">instructor</th>
					<th align="left">dni_nedeli</th>
                </tr>
                <xsl:for-each select="document/uslugi/usluga">
                    <tr>
                        <td><xsl:value-of select="raznovidnost"/></td>
                        <td><xsl:value-of select="stoim"/></td>
						<td><xsl:value-of select="instructor"/></td>
                        <td><xsl:value-of select="dni_nedeli"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
    </html>
</xsl:template></xsl:stylesheet>