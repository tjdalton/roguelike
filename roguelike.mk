##
## Auto Generated makefile by CodeLite IDE
## any manual changes will be erased      
##
## Debug
ProjectName            :=roguelike
ConfigurationName      :=Debug
IntermediateDirectory  :=./Debug
OutDir                 := $(IntermediateDirectory)
WorkspacePath          := "/home/tim/.codelite/programming"
ProjectPath            := "/home/tim/.codelite/programming/roguelike"
CurrentFileName        :=
CurrentFilePath        :=
CurrentFileFullPath    :=
User                   :=tim
Date                   :=29/03/12
CodeLitePath           :="/home/tim/.codelite"
LinkerName             :=g++
ArchiveTool            :=ar rcus
SharedObjectLinkerName :=g++ -shared -fPIC
ObjectSuffix           :=.o
DependSuffix           :=.o.d
PreprocessSuffix       :=.o.i
DebugSwitch            :=-gstab
IncludeSwitch          :=-I
LibrarySwitch          :=-l
OutputSwitch           :=-o 
LibraryPathSwitch      :=-L
PreprocessorSwitch     :=-D
SourceSwitch           :=-c 
CompilerName           :=g++
C_CompilerName         :=gcc
OutputFile             :=$(IntermediateDirectory)/$(ProjectName)
Preprocessors          :=
ObjectSwitch           :=-o 
ArchiveOutputSwitch    := 
PreprocessOnlySwitch   :=-E 
ObjectsFileList        :="/home/tim/.codelite/programming/roguelike/roguelike.txt"
PCHCompileFlags        :=
MakeDirCommand         :=mkdir -p
CmpOptions             := -g -O0 -Wall $(Preprocessors)
C_CmpOptions           := -g -O0 -Wall $(Preprocessors)
LinkOptions            :=  
IncludePath            :=  $(IncludeSwitch). $(IncludeSwitch). 
IncludePCH             := 
RcIncludePath          := 
Libs                   := $(LibrarySwitch)ncurses 
LibPath                := $(LibraryPathSwitch). 


##
## User defined environment variables
##
CodeLiteDir:=/usr/share/codelite
Objects=$(IntermediateDirectory)/world$(ObjectSuffix) $(IntermediateDirectory)/tile$(ObjectSuffix) $(IntermediateDirectory)/item$(ObjectSuffix) $(IntermediateDirectory)/game$(ObjectSuffix) $(IntermediateDirectory)/entity$(ObjectSuffix) $(IntermediateDirectory)/log$(ObjectSuffix) 

##
## Main Build Targets 
##
.PHONY: all clean PreBuild PrePreBuild PostBuild
all: $(OutputFile)

$(OutputFile): $(IntermediateDirectory)/.d $(Objects) 
	@$(MakeDirCommand) $(@D)
	@echo "" > $(IntermediateDirectory)/.d
	@echo $(Objects) > $(ObjectsFileList)
	$(LinkerName) $(OutputSwitch)$(OutputFile) @$(ObjectsFileList) $(LibPath) $(Libs) $(LinkOptions)

$(IntermediateDirectory)/.d:
	@test -d ./Debug || $(MakeDirCommand) ./Debug

PreBuild:


##
## Objects
##
$(IntermediateDirectory)/world$(ObjectSuffix): world.cpp $(IntermediateDirectory)/world$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/world.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/world$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/world$(DependSuffix): world.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/world$(ObjectSuffix) -MF$(IntermediateDirectory)/world$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/world.cpp"

$(IntermediateDirectory)/world$(PreprocessSuffix): world.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/world$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/world.cpp"

$(IntermediateDirectory)/tile$(ObjectSuffix): tile.cpp $(IntermediateDirectory)/tile$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/tile.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/tile$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/tile$(DependSuffix): tile.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/tile$(ObjectSuffix) -MF$(IntermediateDirectory)/tile$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/tile.cpp"

$(IntermediateDirectory)/tile$(PreprocessSuffix): tile.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/tile$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/tile.cpp"

$(IntermediateDirectory)/item$(ObjectSuffix): item.cpp $(IntermediateDirectory)/item$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/item.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/item$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/item$(DependSuffix): item.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/item$(ObjectSuffix) -MF$(IntermediateDirectory)/item$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/item.cpp"

$(IntermediateDirectory)/item$(PreprocessSuffix): item.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/item$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/item.cpp"

$(IntermediateDirectory)/game$(ObjectSuffix): game.cpp $(IntermediateDirectory)/game$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/game.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/game$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/game$(DependSuffix): game.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/game$(ObjectSuffix) -MF$(IntermediateDirectory)/game$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/game.cpp"

$(IntermediateDirectory)/game$(PreprocessSuffix): game.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/game$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/game.cpp"

$(IntermediateDirectory)/entity$(ObjectSuffix): entity.cpp $(IntermediateDirectory)/entity$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/entity.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/entity$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/entity$(DependSuffix): entity.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/entity$(ObjectSuffix) -MF$(IntermediateDirectory)/entity$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/entity.cpp"

$(IntermediateDirectory)/entity$(PreprocessSuffix): entity.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/entity$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/entity.cpp"

$(IntermediateDirectory)/log$(ObjectSuffix): log.cpp $(IntermediateDirectory)/log$(DependSuffix)
	$(CompilerName) $(IncludePCH) $(SourceSwitch) "/home/tim/.codelite/programming/roguelike/log.cpp" $(CmpOptions) $(ObjectSwitch)$(IntermediateDirectory)/log$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/log$(DependSuffix): log.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/log$(ObjectSuffix) -MF$(IntermediateDirectory)/log$(DependSuffix) -MM "/home/tim/.codelite/programming/roguelike/log.cpp"

$(IntermediateDirectory)/log$(PreprocessSuffix): log.cpp
	@$(CompilerName) $(CmpOptions) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/log$(PreprocessSuffix) "/home/tim/.codelite/programming/roguelike/log.cpp"


-include $(IntermediateDirectory)/*$(DependSuffix)
##
## Clean
##
clean:
	$(RM) $(IntermediateDirectory)/world$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/world$(DependSuffix)
	$(RM) $(IntermediateDirectory)/world$(PreprocessSuffix)
	$(RM) $(IntermediateDirectory)/tile$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/tile$(DependSuffix)
	$(RM) $(IntermediateDirectory)/tile$(PreprocessSuffix)
	$(RM) $(IntermediateDirectory)/item$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/item$(DependSuffix)
	$(RM) $(IntermediateDirectory)/item$(PreprocessSuffix)
	$(RM) $(IntermediateDirectory)/game$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/game$(DependSuffix)
	$(RM) $(IntermediateDirectory)/game$(PreprocessSuffix)
	$(RM) $(IntermediateDirectory)/entity$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/entity$(DependSuffix)
	$(RM) $(IntermediateDirectory)/entity$(PreprocessSuffix)
	$(RM) $(IntermediateDirectory)/log$(ObjectSuffix)
	$(RM) $(IntermediateDirectory)/log$(DependSuffix)
	$(RM) $(IntermediateDirectory)/log$(PreprocessSuffix)
	$(RM) $(OutputFile)
	$(RM) "/home/tim/.codelite/programming/.build-debug/roguelike"


