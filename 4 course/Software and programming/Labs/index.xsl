<?xml version="1.0" encoding="ISO-8859-1"?><xsl:stylesheet version="1.0"
                                                           xmlns:xsl="http://www.w3.org/1999/XSL/Transform"><xsl:template match="/">
    <html>
        <body>
            <h2>XSL</h2>
            <table border="1">
                <tr bgcolor="#9acd32">
                    <th align="left">Way</th>
                    <th align="left">Stop</th>
					<th align="left">departure_date</th>
					<th align="left">departure_time</th>
                    <th align="left">Ticket price</th>
					<th align="left">number_free_places</th>
                </tr>
                <xsl:for-each select="document/buses/bus">
                    <tr>
                        <td><xsl:value-of select="way"/></td>
                        <td><xsl:value-of select="stop"/></td>
						<td><xsl:value-of select="departure_date"/></td>
                        <td><xsl:value-of select="departure_time"/></td>
                        <td><xsl:value-of select="ticket_price"/></td>
                        <td><xsl:value-of select="number_free_places"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
    </html>
</xsl:template></xsl:stylesheet>