# Leacme.PagePinger

**Leacme PagePinger** is a cross-platform desktop application able to run on Windows, MacOS, and Linux. It is build using [Microsoft .NET](https://github.com/dotnet/core) platform and [Avalonia UI](https://github.com/AvaloniaUI/Avalonia) framework.

This application features the ability to repeatedly check if a website has updated it's contents from the last time it was parsed.

![][image_screenshot]

## Application Compiling

The desktop application can be compiled into an executable with [.NET 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) by navigating to `Leacme.App.PagePinger` folder and running:
```
dotnet publish --configuration Release -p:CopyOutputSymbolsToPublishDirectory=false -p:PublishSingleFile=true -p:LeacmeOutputType=winexe --runtime win-x64
```
Note: `win-x64` can be replaced with other runtimes such as `linux-x64`, or `osx-x64`, for more runtimes see [RID Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)

## Application Usage

Type in a valid website url ex. http://leac.me and click 'Add Site'. Multiple websites can be added and be parsed for content and will update again once the end of the refresh interval is reached. A notification popup window can also be setup in the Options, showing the old and new content changes.

## Library Usage

The applicatin library can also be build and used separately by navigating to `Leacme.Lib.PagePinger` folder and running `dotnet build`. This will create a .dll library that can be copied into the directory where your .csproj is located. Be sure as well to add the following line to your .csproj file to point to the location of the library:
```
<ItemGroup><Reference Include="Leacme.Lib.PagePinger.dll"><HintPath>Leacme.Lib.PagePinger.dll</HintPath></Reference></ItemGroup>
```
It can then be added and used within your project with `var library = new Leacme.Lib.PagePinger.Library();`

## Copyright
[(c) 2017 Leacme](http://leac.me)

## Contact
The author can be contacted via the contact form on their website http://leac.me

## License
View [LICENSE.md](LICENSE.md) for more information

[image_screenshot]:
data:image/png;base64,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dy8THwCMHTsWhoaGaNGiBcaMGYOQkBC4uLhUOjYiIiIiIiJ6M1XqrtRHjhxBly5d1C5f3H26ZHfl58+f46effsIXX3wBqVSKwsJCFBYWIjk5GVZWVq8UcOkYrl27hk2bNkGhUCApKQm3b99Gs2bNVLY3efLkMrEpFAq0bNkSRkZGwn7Y2toiPDy8Su7OTURERERERG+GSrUYl9eNufS/SqUS9vb22LJlC/z8/DSuUxkVxWBpaQlvb2/s37+/TFftkusV///hw4fIzs6GsbExACA+Ph42Nja8ORcREREREVEdUuVjjEu++vbti6VLl6JRo0ZwdHREQkICdu3ahS+//PKVA1Y3lrn45eDgAEdHR2zfvh0DBgyArq4uwsLCUFhYCH9//zKJMQAEBQVhzJgxiI2Nxfbt2/HDDz8wMSYiIiIiIqpDXuvNt9q2bYvp06dj7dq1+PPPP9GuXTuMHTv2HyWeFT2uaf78+QgKCsLw4cMBAH369MGIESPKJMVKpRLt27eHnZ0dRowYAQCYOXMmXFxcmBgTERERERHVITqBgYHKWbNmFk/WaDDV6eXLl5gwYQJ+++23mg6FiIiIiIiIql1Rg+jKlasq12L8NqqL+0xERERERFTXlbwtVZ1NjEt3wSYiIiIiIqK6o+QNmyv1uKa3Sf369XH48OE6tc9ERERERERURFdXT/h/nW0xJiIiIiIiIgKYGBMREREREVEdV2e7UhMREREREREBbDEmIiIiIiKiOo6JMREREREREdVpTIyJiIiIiIioTlNJjB0dHWsoDCIiIiIiIqLqk5SUKPxftwbjICIiIiIiIqpxTIyJiIiIiIioTmNiTERERERERHUaE2MiIiIiIiKq05gYExERERERUZ3GxJiIiIiIiIjqNCbGREREREREVKcxMSYiIiIiIqI6jYkxERERERER1WlMjImIiIiIiKhOE5WcUCqVNRUHERERERERUY1gizERERERERHVaUyMiYiIiIiIqE5jYkxERERERER1GhNjIiIiIiIiqtOYGBMREREREVGdxsSYiIiIiIiI6jQmxkRERERERFSnMTEmIiIiIiKiOo2JMREREREREdVpTIyJarkJEybg9u3baueFhYVh8uTJ1RxR7REbG4suXbrUdBj/yNuwD3XJ3r174eXlhbZt277W7SxduhTHjx9/rdt4U/n6+iImJua1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jAwkJCTgu+++q/Cu0VQ1avtng4jodare/nZERFSlXF1dMXPmTDx8+BB+fn5YtWpVTYf0RnF3d8eKFStw9uxZtGvXDnv27NF4k7S3RW3fZwMDAxgbGyMgIAAFBQUYMGAAxo4dW9Nh1Qm1/bNBRPQ6sSs1ERERERER1TnsSk1ERERERET0NybGREREREREVKcxMSYiIiIiIqI6jYkxERERERER1WlMjImIiIiIiKhOY2JMREREREREdRoTYyIiIiIiIqrTRCUnlEplTcVBREREREREVCPYYkxERERERER1GhNjIiIiIiIiqtOYGBMREREREVGdxsSYiIiIiIiI6jQmxkRERERERFSnMTEmIiIiIiKiOo2JMREREREREdVpTIyJiIiIiIioTmNiTERERERERHUaE2MiIiIiIiKq05gYExERERERUZ3GxJiIiIiIiIjqNCbGREREREREVKcxMSYiIiIiIqI6TVTTAdCbb82aNTUdAhEREdFb5V//+pfa9zsOGVLNkVBt9MfevTUdwltHJTFWKpU1FQe94WbPnl3TIRARERG9FZYvX17u9/JbBw5UYzRU23gOGsS87TVgizERERER0RtEoVDUdAhEbx0mxkREREREbxAmxkRVj4kxEREREdEbhN1oiaoeE2MiIiIiojcIW4yJqh4f10SvTVBQEDIyMmo6DHoFV69excOHD2s6DK1dvHgRjx8/rukwyqitcRER0ZtNqVS+Na+wsDBMnTpV4/xJkybh9u3bNR5nbXrR68HE+DWIjIzEjBkz0L59ewwcOBC//PIL8vPzAQDnz5/HvHnzhGV79+6NqKioV9pOVFQUGjRoUOb9efPm4ddffwUAZGVlwcDAAAYGBrCxsUHfvn2xfft2lZNq5MiRuHjx4ivF8KqioqJw9uxZlfcuX75cJclYdHQ0Ll++rHGa3h579uxBdnZ2TYfxSrKzs/HDDz/UdBhERPQGUigUtf4VGBiIrl27oqCgoMJllUrlK81LT0/H8uXL4evrC19fX6xcuRKJiYnC/EGDBiEyMhIKhQKrVq3C4cOHa7xequJFrwe7UlcxqVSKCRMmYMqUKVi6dCny8vJw8eJF3LhxA927d4ePjw98fHyqPa64uDhYWVkhOjoaI0aMgKOjI7y9vas9juoQExMDJycnjdP0dsjMzISenh5MTExqOhQiIqJqVduTo+Tk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gbZsccZWFoQumJglG3mEaYyWFpaGa1nLraXOic0t5p13mXOa1d2S1R+Uu8PI/pBg4oLAWXOxVrZAENggt6RJs+LHEcwjfu8/vO9zH0wFPIdzrfN+PP46n+tcXN/3+Xz/evK5rnMAAGgnYQwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACUdtSfa/LHwgEAAKjGiTEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGmtgYumado1BwAAALSFE2MAAABKE8YAAACU1jr2Uzhet//Xf7d7BAAAoIj/uOGado8wYgjjITZr6hntHgEAABjhfr/7H+0eYUTxVmoAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGE8DJ599tn88Ic/zJIlS3LXXXflscceS19fX5Jk8+bN+clPfnLcr7Vv377cdNNNJ2vUf/Gd73wnW7duHbLXW7VqVX7729+e8AxLlizJ4cOH+x976qmnsmzZskHPc6L7/3/e6J5u2bLlqNf82te+lr179w56VgAA4OTw55pOsiNHjuR73/teLr300lx99dV58cUXs23btuzcuTPTp09v93j/Nrq6uvKb3/wmF198cbtHOeY9nTFjRmbMmNHuMQEAgOMkjE+y/fv3Z8eOHfnqV7+aU045JV1dXbnggguSJM8991y+/vWvJ0keeuihvOtd78odd9yRDRs25Pvf/37GjBmT973vfVmwYEGmTZuWJLn77ruzZ8+eXHnllUmS++67Lzt27MiBAwdy2WWXJUn++c9/5pprrsnKlSszatSo/PrXv86GDRvS19eXiy66KPPmzUurNbhb39fXl09/+tNJkilTpuT888/PwoULM2bMmCR5zWtu3rw5DzzwQP9rLFq0KIsWLTqu633kIx/JQw89lAsuuCCnnnrqv3z/0KFDeeSRR/LEE0/k1FNPzbx583L++efnyJEjWbZsWS688MLMmjUrTdNk+fLlec973pNzzjnnNff/WN7oniavnBg/+eSTueqqq/Kzn/0sW7ZsyfXXX58kufXWWzNz5szs3bs3a9asyVNPPZXu7u589KMfzZQpU45rLwAAgKEljE+y0047LdOmTcujjz6aWbNm5fTTT09HR0eSZNKkSVm6dGm2bt2aq666qv/f9PT0pKenJ03TZM+ePVm2bFm+/OUvZ8KECbnlllty++2351vf+lb/83fs2PG619+7d282btyYG2+8MWPHjs327dvzzDPPpLu7e1A/V2dnZx588MEkyQsvvJB169bll7/8ZRYuXPi615w5c2auvvrqvP3tb8/s2bNP6HqTJk3KnDlz8vjjj2f+/PlHfa9pmqxYsSLvfOc7c9ttt+X555/P8uXL89a3vjVTp07Npz71qdxzzz3p7u7Ozp0789JLL+WDH/xgOjo6XnP/j+WN7umrLVq0KNu3b88XvvCFnHXWWUleifhvf/vbWbx4cT7zmc9kz549+cEPfpCvfOUrGTt27AntCwAAMHg+Y3yStVqt3HDDDTl48GDuvffeLF26NA8//PBRn5d9PR0dHXnHO96RD3zgA/nTn/70pq4/atSodHV1ZfTo0enq6sp555036Ch+tbe85S358Ic/nCeeeOKkXnPu3Ln5xS9+kYMHDx71+HPPPZddu3Zl/vz56erqysSJE9PT05Mnn3wyyStRfcUVV+T+++/P6tWrc+WVV75uyB6PwdzTJNm2bVvOPffcTJ8+PZ2dnenu7s7MmTOza9euNz0TAADw5h11Ytw0TbvmGNEmTpyYyy+/PJdffnn27duXVatWZfXq1fnkJz/5ms//85//nLVr12b79u3Zs2dPkvS/FfdETZ48OQsXLsxPf/rTHDlyJNOmTcvs2bPT2dn5pn+eJHn55Zezfv36bNq0Kbt3787hw4fTarXSNM1Ju+aECRPS09OTX/3qV5k6dWr/4wcOHMju3bvzuc99LkeOHElfX19eeumlLFiwoP85M2bMyP33359LLrkkZ5xxxqDmSE78ng60b9++rFmzJuvXrz9q3htvvHHQcwEAUId+GzreSj3MTj/99Fx44YX9v7X4tU4uly9fno9//OP57Gc/m9GjR2fNmjV5+eWXX/f5nZ2d/b8ROcm/nFxOnz4906dPT19fX1atWpXHH388c+fOHdTPsXnz5jz99NO56aabMm7cuPT29ubzn/98mqZJR0fH615zMCe1STJnzpzcdtttR302efz48ZkxY0aWLl36uq+/du3azJ07N7/73e8ye/bsnH322Uleez9P1Kvv6auNGnX0GzMmTJiQT3ziE7niiisGfW0AAGDwvJX6JPvb3/6Wn//853n22WfT19eX/fv3Z9OmTTnnnHOSJGPHju3/XvLK//r09vamq6srp5xySp5++uls3Lix//XGjBmTv//979m/f3//Y2eeeWb++Mc/Zv/+/Tl8+HDWr1/f/71du3Zl06ZNef755/vjemBEv1l9fX3p7OzM6NGj88ILLxz3NceNG5e9e/f2P36ixo8fn8suuywPP/xw/2OTJ0/OWWedlQ0bNuTQoUM5fPhwtmzZ0v/W7q1bt2bXrl352Mc+lsWLF2fFihX987x6/4/Hse7pq02cODF//etf+/9Hb9q0afnDH/6QrVu35sUXX8yBAwfy2GOP5S9/+cub2hMAAGBwnBifZBMnTsy73/3urF69Otu2bcsZZ5yR8847L/PmzUuSdHd358wzz8ySJUsybty43HHHHbn22muzcuXK9Pb25txzz81FF13U/3qjR4/OtddemzvvvDO7d+/Offfd1/9bob/xjW9k0qRJ6enp6X/+lClT8swzz+Tee+9Nb29vZs2addTrHY/bb7/9qPXixYtz6aWXZufOnbn11ltz9tlnH/Wab3TN97///VmxYkWuu+66zJ8//7h/K/VAH/rQh7J27dr+dUdHRxYvXpx169blrrvuSpLMnj07F198cQ4ePJgHHnggX/ziF9PZ2Zn3vve92bZtW9atW5cFCxa85v4fy7Hu6atdcsklWblyZe68884sWbIkM2fOzJe+9KU88sgj+dGPfpTJkydnzpw5edvb3nbCewEAAAxex80339zccsuSJMn48ae1eZx/b//53R9n1tTBf34VAADgjfx+9z9y2/WL2z3Gv7WDBw8kSe6++x5vpQYAAKA2YQwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACU5u8YD7EFCxa0ewQAAGCE+/13f9zuEUYUJ8YAAACUJowBAAAoTRgDAABQ2lGfMW6apl1zjBj2EAAAGA7aY+g4MQYAAKA0YQwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKK01cNE0TbvmGDHsIQAAMBy0x9BxYgwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKK01cNE0TbvmGDHsIQAAMBy0x9BxYgwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKK01cNE0TbvmGDHsIQAAMBy0x9BxYgwAAEBpwhgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUFpr4KJpmnbNMWLYQwAAYDhoj6HjxBgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUFpr4KJpmnbNMWLYQwAAYDhoj6HjxBgAAIDShDEAAAClCWMAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGmtgYumado1x4hhDwEAgOGgPYaOE2MAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGmtgYumado1x4hhDwEAgOGgPYaOE2MAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGmtgYumado1x4hhDwEAgOGgPYaOE2MAAABKE8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGnCGAAAgNJaAxdN07RrjhHDHgIAAMNBewwdJ8YAAACUJowBAAAoTRgDAABQmjAGAACgNGEMAABAacIYAACA0oQxAAAApQljAAAAShPGAAAAlCaMAQAAKE0YAwAAUJowBgAAoDRhDAAAQGnCGAAAgNJaAxdN07RrjhHDHgIA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